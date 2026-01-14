using System.Collections.Generic;
using MySql.Data.MySqlClient;
using QLTL.database;
using QLTL.models;
using System.Windows;
using System;

namespace QLTL.controllers
{
    public class AdministrativeController
    {
        private Database _db;

        public AdministrativeController()
        {
            _db = new Database();
        }

        // Hàm này dùng chung cho cả trang Huyện và trang Xã
        public List<DonVi> GetListDonVi(string type)
        {
            List<DonVi> list = new List<DonVi>();
            string query = "";

            if (type == "Huyen")
            {
                // Lấy danh sách Huyện
                // Giả định bảng tên là: Huyen (cột HuyenID, Ten)
                query = "SELECT * FROM Huyen";
            }
            else if (type == "Xa")
            {
                // Lấy danh sách Xã (Kèm tên Huyện để biết trực thuộc ai)
                // Giả định bảng tên là: Xa (cột XaID, Ten, HuyenID)
                // Dùng JOIN để lấy tên Huyện
                query = "SELECT x.XaID, x.Ten AS TenXa, h.Ten AS TenHuyen " +
                        "FROM Xa x " +
                        "JOIN Huyen h ON x.HuyenID = h.HuyenID";
            }

            try
            {
                if (_db.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DonVi item = new DonVi();

                            if (type == "Huyen")
                            {
                                // Map dữ liệu Huyện vào Model DonVi
                                item.ID = reader.GetInt32("HuyenID");
                                item.TenDonVi = reader.GetString("Ten"); // Cột tên là 'Ten'
                                item.CapTren = "Tỉnh Hải Dương"; // Cấp trên của Huyện là Tỉnh
                                item.MaDonVi = "H" + item.ID; // Tự sinh mã ví dụ
                            }
                            else
                            {
                                // Map dữ liệu Xã vào Model DonVi
                                item.ID = reader.GetInt32("XaID");
                                item.TenDonVi = reader.GetString("TenXa");
                                item.CapTren = reader.GetString("TenHuyen"); // Cấp trên của Xã là Huyện
                                item.MaDonVi = "X" + item.ID;
                            }

                            list.Add(item);
                        }
                    }
                    _db.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu hành chính: " + ex.Message);
            }

            return list;
        }
    }
}