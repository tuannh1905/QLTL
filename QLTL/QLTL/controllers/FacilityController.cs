using MySql.Data.MySqlClient;
using QLTL.models;
using QLTL.database;
using System.Collections.Generic;

namespace QLTL.controllers
{
    public class FacilityController
    {
        private Database _db = new Database();

        // 2.2.3 -> 2.2.14: Tìm kiếm theo Loại (Trạm bơm, Hồ chứa...) và Từ khóa
        public List<CongTrinhThuyLoi> SearchFacilities(string loaiCongTrinh, string keyword)
        {
            List<CongTrinhThuyLoi> list = new List<CongTrinhThuyLoi>();
            // Tìm kiếm theo tên mô tả hoặc địa điểm
            string query = @"SELECT * FROM CongTrinhThuyLoi 
                             WHERE (@loai IS NULL OR LoaiCongTrinh = @loai) 
                             AND (MoTa LIKE @kw OR DiaDiem LIKE @kw)";

            if (_db.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                // Nếu loaiCongTrinh rỗng thì lấy tất cả (cho chức năng bản đồ tổng hợp)
                cmd.Parameters.AddWithValue("@loai", string.IsNullOrEmpty(loaiCongTrinh) ? (object)DBNull.Value : loaiCongTrinh);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CongTrinhThuyLoi item = new CongTrinhThuyLoi();
                        item.CongTrinhID = reader.GetInt32("CongTrinhID");
                        item.LoaiCongTrinh = reader.GetString("LoaiCongTrinh");
                        item.DiaDiem = reader.GetString("DiaDiem");
                        item.MoTa = reader.GetString("MoTa");
                        // Mapping thêm các trường khác...
                        list.Add(item);
                    }
                }
                _db.CloseConnection();
            }
            return list;
        }

        // 2.2.22: Thống kê số lượng công trình theo loại
        public Dictionary<string, int> GetFacilityStatistics()
        {
            var stats = new Dictionary<string, int>();
            string query = "SELECT LoaiCongTrinh, COUNT(*) as SoLuong FROM CongTrinhThuyLoi GROUP BY LoaiCongTrinh";

            if (_db.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        stats.Add(reader.GetString("LoaiCongTrinh"), reader.GetInt32("SoLuong"));
                    }
                }
                _db.CloseConnection();
            }
            return stats;
        }
    }
}