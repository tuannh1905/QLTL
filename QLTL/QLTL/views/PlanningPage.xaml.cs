using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using QLTL.controllers;
using QLTL.models;

namespace QLTL.views
{
    public partial class PlanningPage : Page
    {
        // Khai báo Controller để giao tiếp với Database
        private PlanningController _controller;

        public PlanningPage()
        {
            InitializeComponent();
            _controller = new PlanningController();
        }

        // Sự kiện này chạy tự động khi trang được tải xong (nhờ thuộc tính Loaded="Page_Loaded" bên XAML)
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        // Hàm lấy dữ liệu và đổ vào bảng
        private void LoadData()
        {
            // 1. Gọi Controller lấy danh sách từ MySQL
            List<Planning> list = _controller.GetAllPlannings();

            // 2. Gán dữ liệu vào DataGrid (tên là dtgPlanning)
            // Nếu danh sách có dữ liệu thì hiện, không thì gán null
            if (list != null && list.Count > 0)
            {
                dtgPlanning.ItemsSource = list;
            }
            else
            {
                dtgPlanning.ItemsSource = null;
            }
        }
    }
}