using MySql.Data.MySqlClient;
using QLTL.models;
using QLTL.database;
using System.Collections.Generic;

namespace QLTL.controllers
{
    public class AdministrativeController
    {
        private Database _db = new Database();

        // 1.1 & 1.2: Lấy danh sách và Tìm kiếm Huyện
        public List<Huyen> GetHuyenList(string keyword = "")
        {
            List<Huyen> list = new List<Huyen>();
            string query = "SELECT * FROM Huyen";
            if (!string.IsNullOrEmpty(keyword))
                query += $" WHERE Ten LIKE '%{keyword}%'";

            if (_db.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Huyen
                        {
                            HuyenID = reader.GetInt32("HuyenID"),
                            Ten = reader.GetString("Ten")
                        });
                    }
                }
                _db.CloseConnection();
            }
            return list;
        }

        // 1.3 & 1.4: Lấy danh sách Xã theo Huyện
        public List<Xa> GetXaList(int huyenID)
        {
            List<Xa> list = new List<Xa>();
            string query = $"SELECT * FROM Xa WHERE HuyenID = {huyenID}";

            if (_db.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Xa
                        {
                            XaID = reader.GetInt32("XaID"),
                            Ten = reader.GetString("Ten"),
                            HuyenID = reader.GetInt32("HuyenID")
                        });
                    }
                }
                _db.CloseConnection();
            }
            return list;
        }
    }
}
