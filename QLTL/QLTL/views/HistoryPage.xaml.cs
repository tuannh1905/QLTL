using System.Windows;
using System.Windows.Controls;
using QLTL.controllers;

namespace QLTL.views
{
    public partial class HistoryPage : Page
    {
        private HistoryController _controller;

        public HistoryPage()
        {
            InitializeComponent();
            _controller = new HistoryController();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Load dữ liệu khi mở trang
            dtgHistory.ItemsSource = _controller.GetHistory();
        }
    }
}