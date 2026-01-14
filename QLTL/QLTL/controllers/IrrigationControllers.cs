using MySql.Data.MySqlClient;
using QLTL.database;
using QLTL.models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace QLTL.controllers
{
    public class IrrigationController
    {
        private Database _db;

        public IrrigationController()
        {
            _db = new Database();
        }

        // --- HÀM MỚI (QUAN TRỌNG): Dùng cho trang 2.2.15 ---
        // Hàm này kết nối 3 bảng để lấy Tên Xã và Tên Loại Cây hiển thị lên bảng
        public List<Irrigation> GetIrrigationData()
        {
            List<Irrigation> list = new List<Irrigation>();

            // JOIN 3 BẢNG: dientichtuoitheoxa (t), xa (x), danhmucdientichtuoi (d)
            string query = @"SELECT t.TuoiTheoXaID, t.Vu, t.DienTich, 
                        COALESCE(x.Ten, 'Xã không tồn tại') AS Ten, 
                        COALESCE(d.TenDanhMuc, 'Chưa có loại cây') AS TenDanhMuc 
                 FROM dientichtuoitheoxa t 
                 LEFT JOIN xa x ON t.XaID = x.XaID 
                 LEFT JOIN danhmucdientichtuoi d ON t.DanhMucID = d.DanhMucID
                 ORDER BY t.Vu DESC";

            try
            {
                if (_db.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Irrigation item = new Irrigation();
                            item.ID = reader.GetInt32("TuoiTheoXaID");
                            item.VuMua = reader.GetString("Vu");
                            item.DienTich = reader.GetDouble("DienTich");

                            // Lấy tên Xã và Tên Loại cây
                            item.TenXa = reader.GetString("Ten");
                            item.TenLoaiCay = reader.GetString("TenDanhMuc");

                            list.Add(item);
                        }
                    }
                    _db.CloseConnection();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lấy dữ liệu tưới: " + ex.Message); }
            return list;
        }

        // --- CÁC HÀM CŨ CỦA BẠN (Mình giữ lại để sau này dùng nếu cần lọc chi tiết) ---

        // 2.2.16 & 2.2.18: Lấy dữ liệu tưới theo xã và vụ (trả về ID thô)
        // Lưu ý: Hàm này trả về List<DienTichTuoiTheoXa> -> Bạn cần đảm bảo đã tạo Model này nếu muốn dùng
        /*
        public List<DienTichTuoiTheoXa> GetIrrigationByXa(int xaID, string vuMua)
        {
             // ... Code cũ của bạn ...
             // Tạm thời mình đóng chú thích lại để tránh lỗi nếu bạn chưa tạo model DienTichTuoiTheoXa
             return new List<DienTichTuoiTheoXa>(); 
        }
        */

        // 2.2.21: Thống kê tổng diện tích toàn tỉnh theo vụ
        public double GetTotalAreaBySeason(string vuMua)
        {
            double total = 0;
            string query = "SELECT SUM(DienTich) FROM dientichtuoitheoxa WHERE Vu = @vu";

            try
            {
                if (_db.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    cmd.Parameters.AddWithValue("@vu", vuMua);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        total = Convert.ToDouble(result);

                    _db.CloseConnection();
                }
            }
            catch { }
            return total;
        }
    }
}