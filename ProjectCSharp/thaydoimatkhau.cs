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
    public partial class thaydoimatkhau: UserControl
    {
        private User currentUser;
        private UsersHome usersHome;
        public thaydoimatkhau(User user, UsersHome usersHome)
        {
            InitializeComponent();
            this.currentUser = user;
            this.usersHome = usersHome;
        }
        
        public thaydoimatkhau()
        {
            InitializeComponent();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            txtmatkhaucu.Text = "";
            txtmatkhaumoi.Text = "";
            txtxacnhanmatkhaumoi.Text = "";
            usersHome.ShowThongTinCanhan();
        }

        private void bntthaydoimatkhau_Click(object sender, EventArgs e)
        {
            string username = currentUser.UserName;
            string oldPassword = txtmatkhaucu.Text.Trim();
            string newPassword = txtmatkhaumoi.Text.Trim();
            string confirmPassword = txtxacnhanmatkhaumoi.Text.Trim();
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UserDAO userDAO = new UserDAO();
            string result = userDAO.ChangePassword(username, oldPassword, newPassword);
            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == "Đổi mật khẩu thành công!")
            {
                usersHome.ShowThongTinCanhan();
            }
        }
    }
}
