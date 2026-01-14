using System.Windows;
using System.Windows.Controls;
using QLTL.controllers;

namespace QLTL.views
{
    public partial class ReportPage : Page
    {
        private ReportController _controller;

        public ReportPage()
        {
            InitializeComponent();
            _controller = new ReportController();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Load dữ liệu khi mở trang
            dtgReport.ItemsSource = _controller.GetFacilityReports();
        }
    }
}