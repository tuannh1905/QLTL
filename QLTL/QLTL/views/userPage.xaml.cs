using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using QLTL.controllers;
using QLTL.models;

namespace QLTL.views
{
    public partial class UserPage : Page
    {
        private UserController _userController;

        public UserPage()
        {
            InitializeComponent();
            _userController = new UserController();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUserList();
        }

        // Hàm tải danh sách người dùng từ Database
        private void LoadUserList()
        {
            List<User> users = _userController.GetAllUsers();

            if (users != null && users.Count > 0)
            {
                dtgUsers.ItemsSource = users;
            }
            else
            {
                dtgUsers.ItemsSource = null;
            }
        }

        // --- 1. XỬ LÝ NÚT THÊM MỚI ---
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra quyền hạn
            string currentRole = App.CurrentRole;
            if (string.IsNullOrEmpty(currentRole)) currentRole = "Nhân viên";

            if (currentRole != "Quản lý chung" && currentRole != "Admin")
            {
                MessageBox.Show($"Bạn đang đăng nhập với vai trò: {currentRole}.\n\nChỉ có 'Quản lý chung' mới được phép thêm nhân sự mới!",
                                "Không đủ quyền hạn",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Mở cửa sổ thêm mới
            AddUserWindow addWindow = new AddUserWindow();
            addWindow.ShowDialog();

            // Nếu thêm thành công thì tải lại danh sách
            if (addWindow.IsSuccess)
            {
                LoadUserList();
            }
        }

        // --- 2. XỬ LÝ NÚT XÓA (MỚI THÊM) ---
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // A. Kiểm tra quyền hạn
            string currentRole = App.CurrentRole;
            if (currentRole != "Quản lý chung" && currentRole != "Admin")
            {
                MessageBox.Show("Bạn không có quyền xóa người dùng!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // B. Kiểm tra đã chọn dòng nào chưa
            if (dtgUsers.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Lấy thông tin người dùng đang chọn
            User selectedUser = dtgUsers.SelectedItem as User;

            // C. Chặn xóa chính mình
            if (selectedUser.Username == App.CurrentUser)
            {
                MessageBox.Show("Bạn không thể xóa tài khoản của chính mình đang đăng nhập!", "Lỗi thao tác", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // D. Hỏi xác nhận
            MessageBoxResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản '{selectedUser.Username}' không?\nHành động này không thể hoàn tác.",
                                                      "Xác nhận xóa",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Gọi Controller để xóa
                if (_userController.DeleteUser(selectedUser.Username))
                {
                    MessageBox.Show("Đã xóa thành công!");

                    // Ghi lại lịch sử hệ thống (nếu cần)
                    new HistoryController().AddActivity(App.CurrentUser, $"Đã xóa user: {selectedUser.Username}");

                    // Tải lại danh sách
                    LoadUserList();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại! Vui lòng thử lại.");
                }
            }
        }
    }
}