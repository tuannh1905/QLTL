using System.Windows;
using System.Windows.Controls;
using QLTL.controllers;

namespace QLTL.views
{
    public partial class IrrigationPage : Page
    {
        private IrrigationController _controller;

        public IrrigationPage()
        {
            InitializeComponent();
            _controller = new IrrigationController();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dtgIrrigation.ItemsSource = _controller.GetIrrigationData();
        }
    }
}