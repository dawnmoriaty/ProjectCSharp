using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectCSharp.Component.User;
using ProjectCSharp.DAO;
using ProjectCSharp.Model;

namespace ProjectCSharp
{
    public partial class UsersHome: Form
    {
        private User _user;

        public UsersHome()
        {
            InitializeComponent();
            
        }
        public UsersHome(User user) 
        {

            InitializeComponent();
            _user = user;
        }
        private void UsersHome_Load(object sender, EventArgs e)
        {
            thongtincanhan.Visible = false;
            thaydoimatkhau.Visible = false;
            thaydoithongtin.Visible = false;
            sidebar1.setUsersForm(this);
        }
        // Phương thức truyền từ UserHome sang Sidebar
        public void ShowThongTinCanhan()
        {
            thongtincanhan.Visible = true;
            
        }

        private void thongtincanhan_Paint(object sender, PaintEventArgs e)
        {
            txtFullName.Text = _user.FullName ;
            txtEmail.Text = _user.Email ;
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            thongtincanhan.Visible = false;
            thaydoimatkhau.Visible = true;
        }

        private void btnExitChangePassWord_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtPasswordChange.Text = "";
            txtConfirmPasswordChange.Text = "";
            thaydoimatkhau.Visible = false;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (_user == null)
            {
                MessageBox.Show("Lỗi: Không tìm thấy thông tin người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = _user.UserName; // Dùng _user đã có
            string oldPassword = txtPassword.Text.Trim();
            string newPassword = txtPasswordChange.Text.Trim();
            string confirmPassword = txtConfirmPasswordChange.Text.Trim();

            // Kiểm tra nhập liệu
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

            // Gọi DAO để đổi mật khẩu
            UserDAO userDAO = new UserDAO();
            string result = userDAO.ChangePassword(username, oldPassword, newPassword);

            // Hiển thị kết quả
            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Nếu thành công, ẩn form thay đổi mật khẩu
            if (result == "Đổi mật khẩu thành công!")
            {
                thaydoimatkhau.Visible = false;
            }
        }

        private void btnUpdateInfor_Click(object sender, EventArgs e)
        {
            thongtincanhan.Visible = false;
            thaydoithongtin.Visible = true;
        }

        private void btnExitChangeInformation_Click(object sender, EventArgs e)
        {
            txtEmailChange.Text = "";
            txtFullNameChange.Text = "";
            thaydoithongtin.Visible = false;
        }
    }
}
