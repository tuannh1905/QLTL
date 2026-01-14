namespace QLTL.models
{
    public class Irrigation
    {
        public int ID { get; set; }           // Map từ TuoiTheoXaID
        public string TenXa { get; set; }     // Map từ bảng Xa -> Ten
        public string TenLoaiCay { get; set; } // Map từ bảng DanhMuc -> TenDanhMuc
        public string VuMua { get; set; }     // Map từ cột Vu
        public double DienTich { get; set; }   // Map từ cột DienTich (kiểu DOUBLE)

        // Thuộc tính phụ hiển thị cho đẹp
        public string DienTichHienThi => $"{DienTich} (ha)";
    }
}