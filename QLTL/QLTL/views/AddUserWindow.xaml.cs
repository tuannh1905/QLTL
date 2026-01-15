using QLTL.controllers;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace QLTL.views
{
    public partial class AddUserWindow : Window
    {
        // --- ĐÂY LÀ BIẾN BẠN ĐANG THIẾU ---
        public bool IsSuccess = false;
        // -----------------------------------

        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập và Họ tên!");
                return;
            }

            // 2. Gọi Controller lưu vào DB
            UserController userCtrl = new UserController();

            // Lấy chức vụ từ ComboBox (xử lý tránh null)
            string role = "Nhân viên";
            if (cbRole.SelectedItem is ComboBoxItem item)
            {
                role = item.Content.ToString();
            }

            if (userCtrl.AddUserFull(txtUser.Text, txtPass.Password, txtName.Text, txtEmail.Text, role))
            {
                MessageBox.Show("Thêm mới thành công!");

                // --- ĐÁNH DẤU LÀ THÀNH CÔNG ĐỂ USERPAGE BIẾT ---
                IsSuccess = true;
                // -----------------------------------------------

                this.Close(); // Đóng cửa sổ
            }
            else
            {
                MessageBox.Show("Thêm thất bại (Có thể trùng tên đăng nhập)!");
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}