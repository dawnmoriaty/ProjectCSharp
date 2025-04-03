using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectCSharp.Model;
using ProjectCSharp.DAO;

namespace ProjectCSharp
{
    public partial class thongtincanhan: UserControl
    {
        private User currentUser;
        private UsersHome usersHome;
        public thongtincanhan(User user, UsersHome usersHome)
        {
            InitializeComponent();
            this.currentUser = user;
            this.usersHome = usersHome;
        }
        
        public thongtincanhan()
        {
            InitializeComponent();
        }
        public void LoadUserInfo()
        {
            
                txtTennguoidung.Text = currentUser.FullName;
                txtEmail.Text = currentUser.Email;
            
        }

        private void btnthaydoimatkhau_Click(object sender, EventArgs e)
        {
            usersHome.ShowThayDoiMatKhau();
        }

        private void thongtincanhan_Load(object sender, EventArgs e)
        {
        }

        private void btnthaydoithongtincanhan_Click(object sender, EventArgs e)
        {
            usersHome.ShowThayDoiThongTin();
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
        "Bạn có chắc chắn muốn đăng xuất?",
        "Xác nhận đăng xuất",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (confirm == DialogResult.Yes)
            {
                currentUser = null;

                // Ẩn form UsersHome trước khi mở Home
                usersHome.Hide();

                // Hiển thị lại Home
                Home home = new Home();
                home.Show();

                // Đóng form UsersHome sau khi mở Home
                usersHome.Close();
            }
        }

        private void btnxoataikhoan_Click(object sender, EventArgs e)
        {
            string username = currentUser.UserName;

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tài khoản này? Hành động này không thể hoàn tác!",
                "Xác nhận xóa tài khoản",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                UserDAO userDAO = new UserDAO();
                string result = userDAO.DeleteUser(username);

                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == "Xóa người dùng thành công!")
                {
                    // Đóng form hiện tại (UsersHome)
                    usersHome.Hide();

                    // Hiển thị lại Home
                    Home home = new Home();
                    home.Show();

                    // Đóng form hiện tại
                    usersHome.Close();
                }
            }
        }
    }
}
