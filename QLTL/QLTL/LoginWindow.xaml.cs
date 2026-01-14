using System.Windows;
using QLTL.controllers;
using QLTL.models;

namespace QLTL
{
    public partial class LoginWindow : Window
    {
        private UserController _userController;

        public LoginWindow()
        {
            InitializeComponent();
            _userController = new UserController();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string u = txtUser.Text;
            string p = txtPass.Password;

            if (string.IsNullOrEmpty(u) || string.IsNullOrEmpty(p))
            {
                lblError.Text = "Vui lòng nhập đủ thông tin!";
                return;
            }

            // Gọi hàm Login kiểm tra trong Database
            if (_userController.Login(u, p))
            {
                // --- ĐOẠN CODE MỚI THÊM: GHI LỊCH SỬ ĐĂNG NHẬP ---
                HistoryController historyCtrl = new HistoryController();

                // 1. Tạo phiên làm việc mới (Ghi vào bảng lichsudangnhap)
                // Hàm StartSession() trả về ID phiên -> Lưu vào biến toàn cục
                App.CurrentSessionID = historyCtrl.StartSession();

                // 2. Lưu tên người dùng hiện tại để dùng cho các màn hình khác
                App.CurrentUser = u;

                // 3. Ghi log hành động "Đăng nhập" vào bảng lichsuthaotac
                historyCtrl.AddActivity(u, "Đăng nhập hệ thống");
                // -----------------------------------------------------

                MessageBox.Show("Đăng nhập thành công!", "Thông báo");

                // Mở màn hình chính
                MainWindow main = new MainWindow();
                main.Show();

                // Đóng màn hình đăng nhập
                this.Close();
            }
            else
            {
                lblError.Text = "Sai tài khoản hoặc mật khẩu!";
            }
        }
    }
}
