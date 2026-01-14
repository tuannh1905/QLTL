using MySql.Data.MySqlClient;
using QLTL.database;
using QLTL.models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace QLTL.controllers
{
    public class ReportController
    {
        private Database _db;

        public ReportController()
        {
            _db = new Database();
        }

        // Lấy danh sách Báo cáo công trình + Đếm số file đính kèm
        public List<Report> GetFacilityReports()
        {
            List<Report> list = new List<Report>();

            // SQL: Lấy thông tin báo cáo (b) và đếm số dòng bên bảng tệp đính kèm (t)
            string query = @"SELECT b.BaoCaoID, b.TieuDe, b.LoaiCongTrinh, b.NgayTao, 
                                    COUNT(t.TepID) as SoLuongFile
                             FROM baocaocongtrinh b
                             LEFT JOIN tepdinhkembaocao t ON b.BaoCaoID = t.BaoCaoID
                             GROUP BY b.BaoCaoID, b.TieuDe, b.LoaiCongTrinh, b.NgayTao
                             ORDER BY b.NgayTao DESC";

            try
            {
                if (_db.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Report r = new Report();
                            r.ID = reader.GetInt32("BaoCaoID");
                            r.TieuDe = reader.GetString("TieuDe");

                            // Xử lý null cho Loại công trình
                            r.LoaiCongTrinh = !reader.IsDBNull(reader.GetOrdinal("LoaiCongTrinh"))
                                              ? reader.GetString("LoaiCongTrinh") : "Chung";

                            r.NgayTao = reader.GetDateTime("NgayTao");

                            // Lấy số lượng file đã đếm được (COUNT)
                            r.SoLuongFile = reader.GetInt32("SoLuongFile");

                            list.Add(r);
                        }
                    }
                    _db.CloseConnection();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lấy báo cáo: " + ex.Message); }
            return list;
        }
    }
}
