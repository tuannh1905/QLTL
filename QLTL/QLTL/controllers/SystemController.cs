using MySql.Data.MySqlClient;
using QLTL.models;
using QLTL.database;
using System.Collections.Generic;
using System;

namespace QLTL.controllers
{
    public class SystemController
    {
        private Database _db = new Database();

        // 1.17 -> 1.20: Ghi lại lịch sử (Log)
        // Hàm này nên được gọi bất cứ khi nào User thực hiện Thêm/Sửa/Xóa
        public void LogAction(string username, string thaotac, string cu, string moi)
        {
            // Trước tiên phải lấy ID của phiên đăng nhập gần nhất (logic hơi phức tạp chút)
            // Để đơn giản, ta insert thẳng vào LichSuThaoTac và giả định LichSuID đã có
            string query = @"INSERT INTO LichSuThaoTac (TaiKhoanID, ThaoTac, GiaTriCu, GiaTriMoi, LichSuID) 
                             VALUES (@user, @action, @oldV, @newV, 1)";
            // Số 1 ở cuối là ID phiên đăng nhập giả định, thực tế cần lấy từ Session

            if (_db.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@action", thaotac);
                cmd.Parameters.AddWithValue("@oldV", cu ?? "");
                cmd.Parameters.AddWithValue("@newV", moi ?? "");
                cmd.ExecuteNonQuery();
                _db.CloseConnection();
            }
        }

        // 1.12 & 1.14: Phân quyền cho tài khoản
        public bool GrantPermission(string username, int quyenID)
        {
            string query = "INSERT INTO Quyen_TaiKhoan (TaiKhoanID, QuyenID) VALUES (@user, @quyen)";
            if (_db.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, _db.Connection);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@quyen", quyenID);
                try
                {
                    cmd.ExecuteNonQuery();
                    _db.CloseConnection();
                    return true;
                }
                catch { return false; } // Trùng lặp hoặc lỗi
            }
            return false;
        }
    }
}