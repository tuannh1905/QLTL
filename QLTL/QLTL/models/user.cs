using System;

namespace QLTL.models
{
    public class HoSo
    {
        public int ID { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int DonViID { get; set; }
        public string Email { get; set; }
        public string ChucNang { get; set; }
        public bool Exit_Status { get; set; }
    }

    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string TrangThai { get; set; } 
        public int HoSoID { get; set; }
    }
    public class DonVi
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public int? HanhChinhID { get; set; }
        public int? TruocThuocID { get; set; }
    }
    public class CapHanhChinh
    {
        public int ID { get; set; }
        public string Ten { get; set; } // Trung ương, Tỉnh, Huyện
    }

    public class Quyen
    {
        public int ID { get; set; }
        public string TenQuyen { get; set; }
        public bool XemLichSu { get; set; }
        public bool Exit_Status { get; set; }
    }

    public class LichSuDangNhap
    {
        public int ID { get; set; }
        public DateTime? ThoiDiemDN { get; set; }
        public DateTime? ThoiDiemDX { get; set; }
    }

    public class LichSuThaoTac
    {
        public int ID { get; set; }
        public string TaiKhoanID { get; set; }
        public string ThaoTac { get; set; }
        public string GiaTriCu { get; set; }
        public string GiaTriMoi { get; set; }
        public int LichSuID { get; set; }
    }
}