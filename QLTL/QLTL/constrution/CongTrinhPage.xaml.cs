using System.Windows;
using System.Windows.Controls;
using QLTL.controllers; // Gọi Controller để lấy dữ liệu
using QLTL.models;
using System.Collections.Generic;

namespace QLTL.views
{
    public partial class CongTrinhPage : Page
    {
        // Khai báo Controller
        private FacilityController _controller;

        public CongTrinhPage()
        {
            InitializeComponent();
            _controller = new FacilityController(); // Khởi tạo controller
        }

        // Hàm này chạy ngay khi trang được mở lên (nhờ lệnh Loaded="Page_Loaded" bên XAML)
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Gọi hàm SearchFacilities(null, "") nghĩa là lấy TẤT CẢ, không lọc gì cả
                List<CongTrinhThuyLoi> list = _controller.SearchFacilities(null, "");

                // Đổ dữ liệu vào bảng
                dtgCongTrinh.ItemsSource = list;
            }
            catch
            {
                // Nếu chưa cài Database hoặc lỗi kết nối thì báo nhẹ 1 câu
                // MessageBox.Show("Chưa lấy được dữ liệu. Kiểm tra lại kết nối Database!");
            }
        }
    }
}