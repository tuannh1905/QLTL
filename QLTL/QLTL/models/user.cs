using System;

namespace QLTL.models
{
    // Đặt tên class là User để khớp với Controller
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Nếu trong DB không cần lấy pass ra hiển thị thì có thể bỏ
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string ChucNang { get; set; }
        public bool Exit_Status { get; set; }

        // Mấy trường NgaySinh, DonViID tạm thời chưa dùng tới thì chưa cần khai báo để tránh lỗi dư thừa
    }
}