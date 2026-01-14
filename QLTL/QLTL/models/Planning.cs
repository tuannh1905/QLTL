namespace QLTL.models
{
    public class Planning
    {
        public int KyID { get; set; }
        public string TenKy { get; set; }
        public int NamBatDau { get; set; }
        public int NamKetThuc { get; set; }

        // Thuộc tính phụ: Hiển thị giai đoạn (VD: 2020 - 2025)
        public string GiaiDoan => $"{NamBatDau} - {NamKetThuc}";

        // (Nâng cao) Có thể thêm thuộc tính đếm số lượng bản đồ/báo cáo nếu cần sau này
    }
}
