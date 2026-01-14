using System;

namespace QLTL.models
{
    public class Report
    {
        public int ID { get; set; }             // BaoCaoID
        public string TieuDe { get; set; }      // TieuDe
        public string LoaiCongTrinh { get; set; } // LoaiCongTrinh (VD: Trạm bơm, Hồ chứa)
        public DateTime NgayTao { get; set; }   // NgayTao
        public int SoLuongFile { get; set; }    // Đếm từ bảng tepdinhkembaocao

        // Thuộc tính hiển thị ngày tháng đẹp (VN)
        public string NgayTaoHienThi => NgayTao.ToString("dd/MM/yyyy");

        // Thuộc tính hiển thị số file
        public string FileDinhKem => $"{SoLuongFile} file đính kèm";
    }
}