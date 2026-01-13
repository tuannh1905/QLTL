using MySql.Data.MySqlClient;
using QLTL.models;
using QLTL.database;
using System.Collections.Generic;
using System;

namespace QLTL.controllers
{
    public class PlanningController
    {
        private Database _db = new Database();

        // 2.1.1 & 2.1.2: Lấy danh sách kỳ quy hoạch
        public List<KyQuyHoach> GetAllPlanningPeriods()
        {
            List<KyQuyHoach> list = new List<KyQuyHoach>();
            if (_db.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM KyQuyHoach ORDER BY NamBatDau DESC", _db.Connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KyQuyHoach
                        {
                            KyID = reader.GetInt32("KyID"),
                            TenKy = reader.GetString("TenKy"),
                            NamBatDau = reader.GetInt32("NamBatDau"),
                            NamKetThuc = reader.GetInt32("NamKetThuc")
                        });
                    }
                }
                _db.CloseConnection();
            }
            return list;
        }

        // 2.1.4: Lấy bản đồ quy hoạch theo Kỳ
        public List<BanDoQuyHoach> GetMapsByPeriod(int kyID)
        {
            // Logic tương tự, SELECT * FROM BanDoQuyHoach WHERE KyID = ...
            return new List<BanDoQuyHoach>(); // (Bạn tự viết chi tiết nhé)
        }
    }
}
