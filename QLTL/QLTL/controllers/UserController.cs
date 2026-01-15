using MySql.Data.MySqlClient;
using QLTL.database;
using QLTL.models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace QLTL.controllers
{
    public class UserController
    {
        private Database _db;

        public UserController()
        {
            _db = new Database();
        }

        // --- 1. ĐĂNG NHẬP (Giữ nguyên) ---
        public bool Login(string user, string pass)
        {
            string query = "SELECT COUNT(*) FROM taikhoan WHERE TenDangNhap=@u AND MatKhau=@p";
            try
            {
                if (_db.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    cmd.Parameters.AddWithValue("@u", user);
                    cmd.Parameters.AddWithValue("@p", pass);
                    long count = (long)cmd.ExecuteScalar();
                    _db.CloseConnection();
                    return count > 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi đăng nhập: " + ex.Message); }
            return false;
        }

        // --- 2. LẤY DANH SÁCH (NÂNG CẤP: JOIN VỚI BẢNG HỒ SƠ) ---
        public List<User> GetAllUsers()
        {
            List<User> list = new List<User>();

            // CÂU LỆNH SQL MỚI: Kết nối bảng taikhoan (t) và hoso (h)
            // Dùng LEFT JOIN để nếu tài khoản chưa có hồ sơ thì vẫn hiện ra (nhưng để trống tên)
            string query = @"SELECT t.TenDangNhap, t.TrangThai, t.HoSoID, 
                                    h.HoTen, h.Email, h.Chucnang 
                             FROM taikhoan t 
                             LEFT JOIN hoso h ON t.HoSoID = h.ID";

            try
            {
                if (_db.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User u = new User();

                            // 1. Thông tin cơ bản từ bảng Tài khoản
                            u.ID = !reader.IsDBNull(reader.GetOrdinal("HoSoID")) ? reader.GetInt32("HoSoID") : 0;
                            u.Username = reader.GetString("TenDangNhap");

                            string trangThai = !reader.IsDBNull(reader.GetOrdinal("TrangThai")) ? reader.GetString("TrangThai") : "";
                            u.Exit_Status = (trangThai != "Active");

                            // 2. Thông tin chi tiết từ bảng Hồ sơ (Xử lý cẩn thận nếu null)
                            if (!reader.IsDBNull(reader.GetOrdinal("HoTen")))
                            {
                                u.HoTen = reader.GetString("HoTen");
                            }
                            else
                            {
                                u.HoTen = "Chưa cập nhật";
                            }

                            if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                            {
                                u.Email = reader.GetString("Email");
                            }
                            else
                            {
                                u.Email = "";
                            }

                            if (!reader.IsDBNull(reader.GetOrdinal("Chucnang")))
                            {
                                u.ChucNang = reader.GetString("Chucnang");
                            }
                            else
                            {
                                u.ChucNang = "Nhân viên";
                            }

                            list.Add(u);
                        }
                    }
                    _db.CloseConnection();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lấy DS User: " + ex.Message); }
            return list;
        }

        // --- 3. THÊM MỚI (Giữ nguyên logic cũ, chỉ thêm vào bảng taikhoan) ---
        // Lưu ý: Đúng quy trình là phải thêm vào bảng 'hoso' trước, lấy ID, rồi mới thêm vào 'taikhoan'.
        // Nhưng tạm thời để đơn giản ta cứ thêm tài khoản trước, HoSoID để 0 hoặc NULL.
        public bool AddUser(User u)
        {
            string query = "INSERT INTO taikhoan (TenDangNhap, MatKhau, TrangThai) VALUES (@user, @pass, 'Active')";
            try
            {
                if (_db.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    cmd.Parameters.AddWithValue("@user", u.Username);
                    cmd.Parameters.AddWithValue("@pass", "123456");

                    int result = cmd.ExecuteNonQuery();
                    _db.CloseConnection();
                    return result > 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm User: " + ex.Message); }
            return false;
        }
        // --- 4. LẤY CHỨC VỤ CỦA USER ---
        public string GetUserRole(string username)
        {
            string role = "Nhân viên"; // Mặc định nếu không tìm thấy thì là nhân viên quèn

            // Kết nối bảng Tài khoản sang bảng Hồ sơ để lấy cột 'Chucnang'
            string query = @"SELECT h.Chucnang 
                     FROM taikhoan t 
                     JOIN hoso h ON t.HoSoID = h.ID 
                     WHERE t.TenDangNhap = @user";
            try
            {
                if (_db.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    cmd.Parameters.AddWithValue("@user", username);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        role = result.ToString();
                    }
                    _db.CloseConnection();
                }
            }
            catch (Exception) { }
            return role;
        }
        // --- HÀM THÊM MỚI ĐẦY ĐỦ (Hồ sơ + Tài khoản) ---
        public bool AddUserFull(string username, string password, string fullname, string email, string role)
        {
            // 1. Thêm vào bảng Hồ sơ trước để lấy ID
            string queryHoSo = "INSERT INTO hoso (HoTen, Email, Chucnang) VALUES (@ten, @mail, @chucvu); SELECT LAST_INSERT_ID();";

            int hosoID = 0;

            try
            {
                if (_db.OpenConnection())
                {
                    // A. Insert Hồ sơ
                    MySqlCommand cmd1 = new MySqlCommand(queryHoSo, _db.Connection);
                    cmd1.Parameters.AddWithValue("@ten", fullname);
                    cmd1.Parameters.AddWithValue("@mail", email);
                    cmd1.Parameters.AddWithValue("@chucvu", role);

                    // Lấy ID vừa tạo (ExecuteScalar trả về ID của dòng vừa insert)
                    object result = cmd1.ExecuteScalar();
                    if (result != null) hosoID = Convert.ToInt32(result);

                    // B. Insert Tài khoản (kèm HoSoID vừa lấy được)
                    if (hosoID > 0)
                    {
                        string queryTK = "INSERT INTO taikhoan (TenDangNhap, MatKhau, TrangThai, HoSoID) VALUES (@user, @pass, 'Active', @hid)";
                        MySqlCommand cmd2 = new MySqlCommand(queryTK, _db.Connection);
                        cmd2.Parameters.AddWithValue("@user", username);
                        cmd2.Parameters.AddWithValue("@pass", password);
                        cmd2.Parameters.AddWithValue("@hid", hosoID);

                        cmd2.ExecuteNonQuery();
                    }

                    _db.CloseConnection();
                    return true; // Thành công
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm user: " + ex.Message); }
            return false;
        }
        // --- 5. XÓA NGƯỜI DÙNG ---
        public bool DeleteUser(string username)
        {
            // Lưu ý: Ở đây ta chỉ xóa trong bảng 'taikhoan' để họ không đăng nhập được nữa.
            // Dữ liệu trong bảng 'hoso' vẫn giữ lại để lưu lịch sử (hoặc bạn có thể xóa cả 2 nếu muốn).
            string query = "DELETE FROM taikhoan WHERE TenDangNhap = @user";

            try
            {
                if (_db.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    cmd.Parameters.AddWithValue("@user", username);

                    int result = cmd.ExecuteNonQuery();
                    _db.CloseConnection();
                    return result > 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xóa người dùng: " + ex.Message); }
            return false;
        }
    }
}