using System;

namespace QLTL.models
{
    public class CongTrinhThuyLoi
    {
        public int CongTrinhID { get; set; }
        public string LoaiCongTrinh { get; set; } // Trạm bơm, Đê, Kênh...
        public int? CapID { get; set; }
        public string DiaDiem { get; set; }
        public string MoTa { get; set; }
        public int? TrangThaiID { get; set; }
    }
    public class CapCongTrinh
    {
        public int CapID { get; set; }
        public string TenCap { get; set; }
        public int? HuyenID { get; set; }
        public int? XaID { get; set; }
    }
    public class TrangThai
    {
        public int TrangThaiID { get; set; }
        public double MucNuoc { get; set; }
    }
    public class Huyen
    {
        public int HuyenID { get; set; }
        public string Ten { get; set; }
    }
    public class Xa
    {
        public int XaID { get; set; }
        public string Ten { get; set; }
        public int HuyenID { get; set; }
    }
}
