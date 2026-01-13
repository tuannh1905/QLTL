using System;

namespace QLTL.models
{
    public class DanhMucDienTichTuoi
    {
        public int DanhMucID { get; set; }
        public string TenDanhMuc { get; set; }
    }
    public class DienTichTuoiTheoXa
    {
        public int TuoiTheoXaID { get; set; }
        public string Vu { get; set; } // Vụ Chiêm, Vụ Mùa...
        public double DienTich { get; set; }
        public int XaID { get; set; }
        public int DanhMucID { get; set; }
    }
    public class DienTichTuoiTheoHuyen
    {
        public int TuoiTheoHuyenID { get; set; }
        public string Vu { get; set; }
        public double DienTich { get; set; }
        public int HuyenID { get; set; }
        public int DanhMucID { get; set; }
    }
}
