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

        private void LoadUserList()
        {
            // Gọi hàm GetAllUsers từ Controller
            List<User> users = _userController.GetAllUsers();

            // Đổ dữ liệu vào bảng
            if (users != null && users.Count > 0)
            {
                dtgUsers.ItemsSource = users;
            }
            // Nếu danh sách trống thì gán null để làm sạch bảng
            else
            {
                dtgUsers.ItemsSource = null;
            }
        }

        // --- HÀM MỚI: Xử lý khi bấm nút "Thêm mới" ---
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Mở cửa sổ AddUserWindow dạng hộp thoại
            AddUserWindow addWindow = new AddUserWindow();
            addWindow.ShowDialog();

            // Sau khi đóng cửa sổ thêm (nhập xong hoặc hủy), tải lại danh sách
            LoadUserList();
        }
    }
}