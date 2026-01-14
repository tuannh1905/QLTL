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
    }
}