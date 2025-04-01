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
        private sogiaodich sogiaodich;
        
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
            thaydoimatkhau.Visible = false;
            thaydoithongtin.Visible = false;
            thongtincanhan.Visible = true;
            thongtincanhan.BringToFront();

        }

        private void thongtincanhan_Paint(object sender, PaintEventArgs e)
        {
            // Kiểm tra null = không thì k đăng xuất được @@ á shiba
            if (_user != null)
            {
                txtFullName.Text = _user.FullName;
                txtEmail.Text = _user.Email;
            }
            else
            {
                txtFullName.Text = "";
                txtEmail.Text = "";
            }
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            thongtincanhan.Visible = false;
            thaydoithongtin.Visible = false;
            panel.Visible = false;
            thaydoimatkhau.Visible = true;
            thaydoimatkhau.BringToFront();
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

            string username = _user.UserName; 
            string oldPassword = txtPassword.Text.Trim();
            string newPassword = txtPasswordChange.Text.Trim();
            string confirmPassword = txtConfirmPasswordChange.Text.Trim();
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
                thaydoimatkhau.Visible = false;
            }
        }

        private void btnUpdateInfor_Click(object sender, EventArgs e)
        {
            thongtincanhan.Visible = false;
            thaydoithongtin.Visible = true;
            txtEmailChange.Text = _user.Email;
            txtFullNameChange.Text = _user.FullName;
        }

        private void btnExitChangeInformation_Click(object sender, EventArgs e)
        {
            txtEmailChange.Text = "";
            txtFullNameChange.Text = "";
            thaydoithongtin.Visible = false;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnChangeInformation_Click(object sender, EventArgs e)
        {
            string newFullName = txtFullNameChange.Text.Trim();
            string newEmail = txtEmailChange.Text.Trim();
            if (string.IsNullOrEmpty(newFullName) || string.IsNullOrEmpty(newEmail))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra email hợp lệ
            if (!IsValidEmail(newEmail))
            {
                MessageBox.Show("Email không hợp lệ! Vui lòng kiểm tra lại.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // serivce
            UserDAO userDAO = new UserDAO();
            string result = userDAO.UpdateUserInfo(_user.UserName, newFullName, newEmail);
            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == "Cập nhật thông tin thành công!")
            {
                _user.FullName = newFullName;
                _user.Email = newEmail;
            }
            thaydoithongtin.Visible = false;
            thongtincanhan.Visible = true;
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (_user == null)
            {
                MessageBox.Show("Lỗi: Không tìm thấy thông tin người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = _user.UserName;
            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tài khoản này? Hành động này không thể hoàn tác!",
                "Xác nhận xóa tài khoản",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                UserDAO userDAO = new UserDAO();
                string result = userDAO.DeleteUser(username);
                MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == "Xóa người dùng thành công!")
                {
                    this.Close();
                    Home home = new Home(); 
                    home.Show();
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
        "Bạn có chắc chắn muốn đăng xuất?",
        "Xác nhận đăng xuất",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _user = null;

                // Đóng toàn bộ form đang mở === cái này do gpt gen :D
                foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                {
                    form.Close();
                }
                this.Close();
                Home home = new Home();
                home.Show();
            }
        }
        public void showSogiaodich()
        {
            anthongtincanhan();

            if (!panel.Controls.Contains(sogiaodich.Instance))
            {
                panel.Controls.Add(sogiaodich.Instance);
                sogiaodich.Instance.Dock = DockStyle.Fill; 
                sogiaodich.Instance.BringToFront();
            }
            else
            {
                sogiaodich.Instance.BringToFront();
            }

        }

        public void anthongtincanhan()
        {
            thongtincanhan.Visible = false;
            thaydoimatkhau.Visible = false;
            thaydoithongtin.Visible = false;
        }

        
    }
}
