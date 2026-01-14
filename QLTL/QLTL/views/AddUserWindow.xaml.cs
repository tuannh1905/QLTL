using System.Windows;
using System.Windows.Controls;
using QLTL.controllers;
using QLTL.models;

namespace QLTL.views
{
    public partial class AddUserWindow : Window
    {
        private UserController _controller;

        public AddUserWindow()
        {
            InitializeComponent();
            _controller = new UserController();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập và Họ tên!");
                return;
            }

            // 2. Tạo đối tượng User
            User newUser = new User();
            newUser.Username = txtUser.Text;
            newUser.HoTen = txtHoTen.Text;
            newUser.Email = txtEmail.Text;
            newUser.ChucNang = cbRole.Text;

            // 3. Gọi Controller để lưu
            if (_controller.AddUser(newUser))
            {
                MessageBox.Show("Thêm thành công! Mật khẩu mặc định là: 123456");
                this.Close(); // Đóng cửa sổ nhập
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}