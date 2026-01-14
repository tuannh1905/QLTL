using System;

namespace QLTL.models
{
    public class History
    {
        public int ID { get; set; }
        public string TenDangNhap { get; set; } // Map từ cột TaiKhoanID
        public string HanhDong { get; set; }    // Map từ cột ThaoTac
        public DateTime ThoiGian { get; set; }  // Map từ cột ThoiDiemDN

        // Thuộc tính phụ: Để hiển thị giờ đẹp lên bảng (dd/MM/yyyy HH:mm)
        public string ThoiGianHienThi => ThoiGian.ToString("dd/MM/yyyy HH:mm:ss");
    }
}