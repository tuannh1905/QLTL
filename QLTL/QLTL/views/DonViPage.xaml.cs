using System.Windows;
using System.Windows.Controls;
using QLTL.controllers;

namespace QLTL.views
{
    public partial class DonViPage : Page
    {
        private AdministrativeController _controller;
        private string _loaiHienThi; // Biến này lưu "Huyen" hoặc "Xa"

        // Constructor nhận tham số type
        public DonViPage(string type)
        {
            InitializeComponent();
            _controller = new AdministrativeController();
            _loaiHienThi = type;

            // Đổi tiêu đề cho đúng nghiệp vụ
            if (_loaiHienThi == "Huyen")
            {
                lblTitle.Text = "DANH SÁCH QUẬN / HUYỆN";
            }
            else
            {
                lblTitle.Text = "DANH SÁCH XÃ / PHƯỜNG";
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // Gọi hàm GetListDonVi từ Controller mà chúng ta vừa sửa
            dtgDonVi.ItemsSource = _controller.GetListDonVi(_loaiHienThi);
        }
    }
}