using System;

namespace QLTL.models
{
    public class BaoCaoCongTrinh
    {
        public int BaoCaoID { get; set; }
        public int CongTrinhID { get; set; }
        public string LoaiCongTrinh { get; set; }
        public string TieuDe { get; set; }
        public DateTime? NgayTao { get; set; }
    }
    public class TepDinhKemBaoCao
    {
        public int TepID { get; set; }
        public string TepDinhKem { get; set; } // Tên file hoặc đường dẫn
        public string MoTa { get; set; }
        public int BaoCaoID { get; set; }
    }
    public class KyQuyHoach
    {
        public int KyID { get; set; }
        public string TenKy { get; set; }
        public int NamBatDau { get; set; }
        public int NamKetThuc { get; set; }
    }
    public class BaoCaoQuyHoach
    {
        public int BaoCaoID { get; set; }
        public string TieuDe { get; set; }
        public string TepDinhKem { get; set; }
        public int KyID { get; set; }
    }
    public class BanDoQuyHoach
    {
        public int BanDoID { get; set; }
        public string TenBanDo { get; set; }
        public int KyID { get; set; }
    }
}
