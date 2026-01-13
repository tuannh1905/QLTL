using System.Windows;
using System.Windows.Controls;
using QLTL.views; // Chúng ta sắp tạo thư mục này

namespace QLTL
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Xử lý khi bấm vào các mục trong Menu
        private void MenuTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TreeViewItem item && item.Tag != null)
            {
                string tag = item.Tag.ToString();

                switch (tag)
                {
                    case "Fac_List":
                        // Mở trang danh sách công trình
                        MainFrame.Navigate(new CongTrinhPage());
                        break;

                    case "Admin_User":
                        MessageBox.Show("Chức năng Quản lý người dùng đang phát triển");
                        break;

                    // Các case khác bạn sẽ thêm dần sau...
                    default:
                        break;
                }
            }
        }

        // Nút đăng xuất
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}