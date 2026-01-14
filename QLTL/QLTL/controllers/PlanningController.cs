using MySql.Data.MySqlClient;
using QLTL.database;
using QLTL.models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace QLTL.controllers
{
    public class PlanningController
    {
        private Database _db;

        public PlanningController()
        {
            _db = new Database();
        }

        // Hàm lấy danh sách tất cả các Kỳ quy hoạch
        public List<Planning> GetAllPlannings()
        {
            List<Planning> list = new List<Planning>();

            // Lấy dữ liệu sắp xếp theo năm mới nhất (NamBatDau giảm dần)
            string query = "SELECT KyID, TenKy, NamBatDau, NamKetThuc FROM kyquyhoach ORDER BY NamBatDau DESC";

            try
            {
                if (_db.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Planning p = new Planning();

                            // Map dữ liệu từ Database vào Model
                            p.KyID = reader.GetInt32("KyID");
                            p.TenKy = reader.GetString("TenKy");

                            // Xử lý cột NamBatDau (Nếu trong DB để trống NULL thì gán bằng 0)
                            if (!reader.IsDBNull(reader.GetOrdinal("NamBatDau")))
                            {
                                p.NamBatDau = reader.GetInt32("NamBatDau");
                            }
                            else
                            {
                                p.NamBatDau = 0;
                            }

                            // Xử lý cột NamKetThuc tương tự
                            if (!reader.IsDBNull(reader.GetOrdinal("NamKetThuc")))
                            {
                                p.NamKetThuc = reader.GetInt32("NamKetThuc");
                            }
                            else
                            {
                                p.NamKetThuc = 0;
                            }

                            list.Add(p);
                        }
                    }
                    _db.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu Quy hoạch: " + ex.Message);
            }

            return list;
        }
    }
}