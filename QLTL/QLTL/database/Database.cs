using MySql.Data.MySqlClient;
using System.Data;

namespace QLTL.database
{
    public class Database
    {
        private string connectionString = "Server=quanlythuyloi;Database=qaunlythuyloi;Uid=root;Pwd=Ta19050500@;Charset=utf8;";

        public MySqlConnection Connection { get; set; }

        public Database()
        {
            Connection = new MySqlConnection(connectionString);
        }
        public bool OpenConnection()
        {
            try
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi kết nối: " + ex.Message);
            }
            return false;
        }
        public void CloseConnection()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}
