using QLTL.controllers;
using QLTL.views;
using System.Windows;
using System.Windows.Controls;

namespace QLTL
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TreeViewItem item && item.Tag != null)
            {
                string tag = item.Tag.ToString();

                // Dùng switch-case để điều hướng thông minh
                switch (tag)
                {
                    // --- NHÓM 1: QUẢN TRỊ HỆ THỐNG ---

                    // 1.1 Quản lý Huyện
                    case "Admin_Huyen":
                        MainFrame.Navigate(new DonViPage("Huyen"));
                        break;

                    // 1.1 Quản lý Xã
                    case "Admin_Xa":
                        MainFrame.Navigate(new DonViPage("Xa"));
                        break;

                    // 1.5 Quản lý Người dùng
                    case "Admin_UserList":
                        MainFrame.Navigate(new UserPage());
                        break;

                    // 1.17 Lịch sử truy cập
                    case "Admin_History":
                        MainFrame.Navigate(new HistoryPage());
                        break;

                    // --- NHÓM 2: CÔNG TRÌNH THỦY LỢI ---

                    // 2.1 QUY HOẠCH & BẢN ĐỒ (Đã thêm mới đoạn này)
                    case "Fac_Planning":
                        MainFrame.Navigate(new PlanningPage());
                        break;

                    // 2.2 Danh sách Công trình
                    case "Fac_List":
                        MainFrame.Navigate(new CongTrinhPage("")); // "" = Lấy tất cả
                        break;

                    // Các case lọc chi tiết (Nếu bạn đã gắn Tag bên XAML thì giữ lại)
                    case "Fac_Dam":
                        MainFrame.Navigate(new CongTrinhPage("Đập tràn"));
                        break;
                    case "Fac_Reservoir":
                        MainFrame.Navigate(new CongTrinhPage("Hồ chứa"));
                        break;
                    case "Fac_Pump":
                        MainFrame.Navigate(new CongTrinhPage("Trạm bơm"));
                        break;
                    case "Fac_Canal":
                        MainFrame.Navigate(new CongTrinhPage("Kênh mương"));
                        break;
                    case "Fac_Pipeline":
                        MainFrame.Navigate(new CongTrinhPage("Đường ống"));
                        break;
                    case "Fac_Dyke":
                        MainFrame.Navigate(new CongTrinhPage("Hệ thống đê"));
                        break;

                    // --- CÁC CHỨC NĂNG KHÁC ---
                    case "Acc_ChangePass":
                        MessageBox.Show("Tính năng Đổi mật khẩu đang cập nhật...");
                        break;
                    case "Fac_Irrigation":
                        MainFrame.Navigate(new IrrigationPage());
                        break;
                    // --- NHÓM THỐNG KÊ / BÁO CÁO ---
                    case "Stat_Report":
                        MainFrame.Navigate(new ReportPage());
                        break;

                    default:
                        // Những tag lạ hoặc chưa xử lý
                        break;
                }
            }
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            // Cập nhật giờ đăng xuất vào DB
            HistoryController historyCtrl = new HistoryController();
            historyCtrl.EndSession();

            // Reset biến toàn cục
            App.CurrentSessionID = 0;
            App.CurrentUser = "";

            // Quay lại màn hình đăng nhập
            new LoginWindow().Show();
            this.Close();
        }
    }
}