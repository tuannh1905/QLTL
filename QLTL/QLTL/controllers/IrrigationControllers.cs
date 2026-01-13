using MySql.Data.MySqlClient;
using QLTL.models;
using QLTL.database;
using System.Collections.Generic;

namespace QLTL.controllers
{
    public class IrrigationController
    {
        private Database _db = new Database();

        // 2.2.16 & 2.2.18: Lấy dữ liệu tưới theo xã và vụ
        public List<DienTichTuoiTheoXa> GetIrrigationByXa(int xaID, string vuMua)
        {
            List<DienTichTuoiTheoXa> list = new List<DienTichTuoiTheoXa>();
            string query = @"SELECT * FROM DienTichTuoiTheoXa 
                             WHERE (XaID = @xaID) AND (@vu IS NULL OR Vu = @vu)";

            if (_db.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                cmd.Parameters.AddWithValue("@xaID", xaID);
                cmd.Parameters.AddWithValue("@vu", string.IsNullOrEmpty(vuMua) ? (object)DBNull.Value : vuMua);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DienTichTuoiTheoXa
                        {
                            TuoiTheoXaID = reader.GetInt32("TuoiTheoXaID"),
                            Vu = reader.GetString("Vu"),
                            DienTich = reader.GetDouble("DienTich"),
                            XaID = reader.GetInt32("XaID"),
                            DanhMucID = reader.GetInt32("DanhMucID")
                        });
                    }
                }
                _db.CloseConnection();
            }
            return list;
        }

        // 2.2.21: Thống kê tổng diện tích toàn tỉnh theo vụ
        public double GetTotalAreaBySeason(string vuMua)
        {
            double total = 0;
            string query = "SELECT SUM(DienTich) FROM DienTichTuoiTheoXa WHERE Vu = @vu";

            if (_db.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                cmd.Parameters.AddWithValue("@vu", vuMua);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    total = Convert.ToDouble(result);

                _db.CloseConnection();
            }
            return total;
        }
    }
}