namespace QLTL.models
{
    public class DonVi
    {
        public int ID { get; set; }
        public string TenDonVi { get; set; } // Tên Huyện hoặc Tên Xã
        public string CapTren { get; set; }  // Nếu là Xã thì cột này hiện tên Huyện trực thuộc

        // Cột ghi chú hoặc mã đơn vị (nếu có trong DB)
        public string MaDonVi { get; set; }
    }
}
