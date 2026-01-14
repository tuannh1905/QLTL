using System.Configuration;
using System.Data;
using System.Windows;

namespace QLTL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // --- THÊM 2 DÒNG NÀY ---

        // 1. Lưu ID của phiên đăng nhập (để biết thao tác nào thuộc về lần đăng nhập nào)
        public static int CurrentSessionID = 0;

        // 2. Lưu tên người dùng hiện tại (để hiển thị "Xin chào..." hoặc ghi log)
        public static string CurrentUser = "";
    }
}