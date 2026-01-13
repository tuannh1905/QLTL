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
