using System.Data;
using MySql.Data.MySqlClient;
using System.Windows; // Thư viện để dùng MessageBox

namespace QLTL.database
{
    public class Database
    {
        // --- CẤU HÌNH KẾT NỐI ---
        // Lưu ý: Sửa '123456' thành mật khẩu MySQL trên máy bạn.
        // Nếu dùng XAMPP mặc định thì xóa '123456' đi (để trống: Pwd=;)
        private string connectionString = "Server=127.0.0.1;Database=QuanLyThuyLoi;Uid=root;Pwd = Ta19050500@;Charset=utf8;";

        public MySqlConnection Connection { get; set; }

        public Database()
        {
            Connection = new MySqlConnection(connectionString);
        }

        // Hàm mở kết nối
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
                // Hiện bảng thông báo lỗi cụ thể để biết đường sửa
                MessageBox.Show("Lỗi kết nối MySQL: " + ex.Message, "Lỗi Hệ Thống");
            }
            return false;
        }

        // Hàm đóng kết nối
        public void CloseConnection()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}