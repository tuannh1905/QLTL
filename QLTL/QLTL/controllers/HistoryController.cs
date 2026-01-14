using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using QLTL.database;
using QLTL.models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace QLTL.controllers
{
    public class HistoryController
    {
        private Database _db;

        public HistoryController()
        {
            _db = new Database();
        }

        // --- 1. BẮT ĐẦU PHIÊN (Ghi vào bảng lichsudangnhap) ---
        // Hàm này trả về ID của phiên vừa tạo để dùng cho các thao tác sau
        public int StartSession()
        {
            int sessionID = 0;
            // Chỉ ghi thời điểm đăng nhập (ThoiDiemDN), ThoiDiemDX để NULL
            string query = "INSERT INTO lichsudangnhap (ThoiDiemDN) VALUES (@time); SELECT LAST_INSERT_ID();";

            try
            {
                if (_db.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);

                    // Thực thi và lấy về ID vừa tạo (Hàm ExecuteScalar lấy giá trị đầu tiên)
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        sessionID = Convert.ToInt32(result);
                    }
                    _db.CloseConnection();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tạo session: " + ex.Message); }
            return sessionID;
        }

        // --- 2. GHI THAO TÁC (Ghi vào bảng lichsuthaotac) ---
        public void AddActivity(string username, string action)
        {
            // Kiểm tra: Nếu chưa có phiên đăng nhập (ID=0) thì không ghi
            if (App.CurrentSessionID == 0) return;

            string query = "INSERT INTO lichsuthaotac (TaiKhoanID, ThaoTac, LichSuID) VALUES (@u, @a, @sid)";
            try
            {
                if (_db.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    cmd.Parameters.AddWithValue("@u", username); // Lưu tên đăng nhập (VD: HuyenTK)
                    cmd.Parameters.AddWithValue("@a", action);   // Lưu hành động
                    cmd.Parameters.AddWithValue("@sid", App.CurrentSessionID); // ID phiên (Lấy từ App.xaml.cs)

                    cmd.ExecuteNonQuery();
                    _db.CloseConnection();
                }
            }
            catch (Exception) { /* Lỗi ghi log thao tác thì bỏ qua */ }
        }

        // --- 3. KẾT THÚC PHIÊN (Cập nhật giờ đăng xuất) ---
        public void EndSession()
        {
            if (App.CurrentSessionID == 0) return;

            string query = "UPDATE lichsudangnhap SET ThoiDiemDX = @time WHERE ID = @id";
            try
            {
                if (_db.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id", App.CurrentSessionID);
                    cmd.ExecuteNonQuery();
                    _db.CloseConnection();
                }
            }
            catch (Exception) { }
        }

        // --- 4. LẤY DANH SÁCH HIỂN THỊ (Kết nối 2 bảng) ---
        public List<History> GetHistory()
        {
            List<History> list = new List<History>();

            // JOIN bảng lichsuthaotac (t) với lichsudangnhap (d)
            // Để lấy được: Ai làm gì (t) vào thời gian nào (d)
            string query = @"SELECT t.ID, t.TaiKhoanID, t.ThaoTac, d.ThoiDiemDN 
                             FROM lichsuthaotac t 
                             JOIN lichsudangnhap d ON t.LichSuID = d.ID 
                             ORDER BY d.ThoiDiemDN DESC, t.ID DESC";

            try
            {
                if (_db.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            History h = new History();
                            h.ID = reader.GetInt32("ID");

                            // Map dữ liệu từ SQL vào Model
                            h.TenDangNhap = reader.GetString("TaiKhoanID"); // Cột TaiKhoanID chứa tên username
                            h.HanhDong = reader.GetString("ThaoTac");
                            h.ThoiGian = reader.GetDateTime("ThoiDiemDN"); // Lấy thời gian bắt đầu phiên

                            list.Add(h);
                        }
                    }
                    _db.CloseConnection();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lấy lịch sử: " + ex.Message); }
            return list;
        }
    }
}
