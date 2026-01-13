using MySql.Data.MySqlClient;
using QLTL.models;
using QLTL.database;
using System;
using System.Data;

namespace QLTL.controllers
{
    public class UserController
    {
        private Database _db;

        public UserController()
        {
            _db = new Database();
        }

        // --- 1. ĐĂNG NHẬP (LOGIN) ---
        public bool Login(string username, string password)
        {
            // Lưu ý: Thực tế nên mã hóa password (MD5/SHA256) trước khi so sánh
            string query = "SELECT Count(*) FROM TaiKhoan WHERE TenDangNhap = @user AND MatKhau = @pass AND TrangThai = 'Active'";

            if (_db.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password); // Nếu DB đã mã hóa thì chỗ này phải mã hóa password nhập vào

                long count = (long)cmd.ExecuteScalar();
                _db.CloseConnection();
                return count > 0;
            }
            return false;
        }

        // --- 2. ĐĂNG KÝ (REGISTER) - QUAN TRỌNG ---
        // Nghiệp vụ: Đăng ký cần tạo hồ sơ trước -> lấy ID hồ sơ -> tạo tài khoản
        // Phải dùng Transaction để đảm bảo nếu tạo TK lỗi thì không tạo Hồ sơ rác
        public string Register(string username, string password, string fullname, string email)
        {
            if (_db.OpenConnection())
            {
                MySqlTransaction transaction = _db.Connection.BeginTransaction();
                try
                {
                    // Bước 1: Kiểm tra trùng tên đăng nhập
                    MySqlCommand checkCmd = new MySqlCommand("SELECT Count(*) FROM TaiKhoan WHERE TenDangNhap = @user", _db.Connection, transaction);
                    checkCmd.Parameters.AddWithValue("@user", username);
                    if ((long)checkCmd.ExecuteScalar() > 0)
                    {
                        return "Tên đăng nhập đã tồn tại!";
                    }

                    // Bước 2: Tạo Hồ Sơ mới
                    // Giả sử mặc định Exit_Status là false (0)
                    string insertHoSo = @"INSERT INTO HoSo (HoTen, Email, Exit_Status) VALUES (@name, @email, 0); 
                                          SELECT LAST_INSERT_ID();";

                    MySqlCommand cmdHoSo = new MySqlCommand(insertHoSo, _db.Connection, transaction);
                    cmdHoSo.Parameters.AddWithValue("@name", fullname);
                    cmdHoSo.Parameters.AddWithValue("@email", email);

                    // Lấy ID của hồ sơ vừa tạo
                    int hosoId = Convert.ToInt32(cmdHoSo.ExecuteScalar());

                    // Bước 3: Tạo Tài Khoản gắn với Hồ Sơ đó
                    string insertTK = @"INSERT INTO TaiKhoan (TenDangNhap, MatKhau, TrangThai, HoSoID) 
                                        VALUES (@user, @pass, 'Active', @hosoId)";

                    MySqlCommand cmdTK = new MySqlCommand(insertTK, _db.Connection, transaction);
                    cmdTK.Parameters.AddWithValue("@user", username);
                    cmdTK.Parameters.AddWithValue("@pass", password);
                    cmdTK.Parameters.AddWithValue("@hosoId", hosoId);
                    cmdTK.ExecuteNonQuery();

                    // Bước 4: (Tùy chọn) Phân quyền mặc định cho user mới (Ví dụ quyền Xem - ID 3)
                    string insertQuyen = "INSERT INTO Quyen_TaiKhoan (TaiKhoanID, QuyenID) VALUES (@user, 3)";
                    MySqlCommand cmdQuyen = new MySqlCommand(insertQuyen, _db.Connection, transaction);
                    cmdQuyen.Parameters.AddWithValue("@user", username);
                    cmdQuyen.ExecuteNonQuery();

                    // Nếu mọi thứ ok thì Commit (Lưu thật)
                    transaction.Commit();
                    _db.CloseConnection();
                    return "Success";
                }
                catch (Exception ex)
                {
                    // Có lỗi thì Rollback (Hoàn tác mọi thứ)
                    transaction.Rollback();
                    _db.CloseConnection();
                    return "Lỗi đăng ký: " + ex.Message;
                }
            }
            return "Lỗi kết nối CSDL";
        }

        // --- 3. ĐỔI MẬT KHẨU (CHANGE PASSWORD) ---
        public bool ChangePassword(string username, string oldPass, string newPass)
        {
            string query = "UPDATE TaiKhoan SET MatKhau = @newPass WHERE TenDangNhap = @user AND MatKhau = @oldPass";

            if (_db.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@oldPass", oldPass);
                cmd.Parameters.AddWithValue("@newPass", newPass);

                int result = cmd.ExecuteNonQuery();
                _db.CloseConnection();

                // Nếu result > 0 tức là update thành công (Username và Pass cũ đúng)
                return result > 0;
            }
            return false;
        }

        // --- 4. QUÊN MẬT KHẨU (FORGOT PASSWORD) ---
        // Kiểm tra xem User và Email có khớp nhau không để cho phép reset
        public bool CheckUserEmailMatch(string username, string email)
        {
            string query = @"SELECT Count(*) FROM TaiKhoan tk 
                             JOIN HoSo hs ON tk.HoSoID = hs.ID 
                             WHERE tk.TenDangNhap = @user AND hs.Email = @email";

            if (_db.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@email", email);

                long count = (long)cmd.ExecuteScalar();
                _db.CloseConnection();
                return count > 0;
            }
            return false;
        }

        // --- 5. LẤY THÔNG TIN USER (Đã có từ trước) ---
        public HoSo GetUserInfo(string username)
        {
            HoSo userProfile = null;
            string query = @"SELECT hs.* FROM HoSo hs 
                             JOIN TaiKhoan tk ON hs.ID = tk.HoSoID 
                             WHERE tk.TenDangNhap = @user";

            if (_db.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                cmd.Parameters.AddWithValue("@user", username);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userProfile = new HoSo();
                        userProfile.ID = reader.GetInt32("ID");
                        userProfile.HoTen = reader.GetString("HoTen");
                        userProfile.Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString("Email");
                        // Thêm các trường khác...
                    }
                }
                _db.CloseConnection();
            }
            return userProfile;
        }
    }
}
