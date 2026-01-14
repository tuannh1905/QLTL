using System.Windows;
using System.Windows.Controls;
using QLTL.controllers;
using System.Collections.Generic;

namespace QLTL.views
{
    public partial class CongTrinhPage : Page
    {
        private FacilityController _controller;
        private string _loaiCongTrinh; // Biến lưu loại công trình hiện tại (VD: Trạm bơm)

        // Sửa Constructor để nhận tham số loại công trình
        public CongTrinhPage(string loaiCongTrinh = "")
        {
            InitializeComponent();
            _controller = new FacilityController();
            _loaiCongTrinh = loaiCongTrinh;

            // Đổi tiêu đề trang cho đúng nghiệp vụ
            if (!string.IsNullOrEmpty(_loaiCongTrinh))
                lblTitle.Text = "DANH SÁCH " + _loaiCongTrinh.ToUpper();
            else
                lblTitle.Text = "TOÀN BỘ CÔNG TRÌNH THỦY LỢI";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Truyền _loaiCongTrinh vào hàm tìm kiếm để lọc
                // Tham số thứ 2 là từ khóa tìm kiếm (đang để trống)
                var list = _controller.SearchFacilities(_loaiCongTrinh, "");
                dtgCongTrinh.ItemsSource = list;
            }
            catch
            {
                // Xử lý lỗi lặng lẽ hoặc log ra file
            }
        }
    }
}