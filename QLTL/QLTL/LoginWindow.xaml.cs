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

            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(u) || string.IsNullOrEmpty(p))
            {
                // Lưu ý: Nếu lblError bên XAML là TextBlock thì dùng .Text, là Label thì dùng .Content
                if (lblError != null) lblError.Text = "Vui lòng nhập đủ thông tin!";
                return;
            }

            // 2. Gọi hàm Login kiểm tra trong Database
            if (_userController.Login(u, p))
            {
                // --- A. GHI LỊCH SỬ HỆ THỐNG ---
                HistoryController historyCtrl = new HistoryController();

                // Tạo phiên làm việc mới -> Lưu ID phiên vào biến toàn cục
                App.CurrentSessionID = historyCtrl.StartSession();

                // Lưu tên người dùng hiện tại
                App.CurrentUser = u;

                // --- B. QUAN TRỌNG: LẤY CHỨC VỤ (ROLE) ---
                // Gọi hàm GetUserRole vừa viết trong UserController
                App.CurrentRole = _userController.GetUserRole(u);
                // ------------------------------------------

                // Ghi log hành động "Đăng nhập"
                historyCtrl.AddActivity(u, "Đăng nhập hệ thống");


                // --- C. THÔNG BÁO VÀ CHUYỂN MÀN HÌNH ---
                // Hiển thị luôn vai trò để kiểm tra xem code chạy đúng chưa
                MessageBox.Show($"Đăng nhập thành công!\nXin chào: {u}\nVai trò: {App.CurrentRole}", "Thông báo");

                // Mở màn hình chính
                MainWindow main = new MainWindow();
                main.Show();

                // Đóng màn hình đăng nhập
                this.Close();
            }
            else
            {
                if (lblError != null) lblError.Text = "Sai tài khoản hoặc mật khẩu!";
            }
        }
    }
}