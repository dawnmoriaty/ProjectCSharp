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
    public partial class thaydoithongtincanhan: UserControl
    {
        private User currentUser;
        private UsersHome usersHome;
        public thaydoithongtincanhan()
        {
            InitializeComponent();
        }
        public thaydoithongtincanhan(User user,UsersHome usersHome)
        {
            InitializeComponent();
            this.usersHome = usersHome;
            this.currentUser = user;
        }
        public void LoadUserInfo()
        {
            if (currentUser != null)
            {
                txtTenthaydoi.Text = currentUser.FullName;
                txtemailthaydoi.Text = currentUser.Email;
            }
        }

        private void btnExitChangeInformation_Click(object sender, EventArgs e)
        {
            txtemailthaydoi.Text = "";
            txtTenthaydoi.Text = "";
            usersHome.ShowThongTinCanhan();
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
            string newFullName = txtTenthaydoi.Text.Trim();
            string newEmail = txtemailthaydoi.Text.Trim();
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
            string result = userDAO.UpdateUserInfo(currentUser.UserName, newFullName, newEmail);
            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == "Cập nhật thông tin thành công!")
            {
                currentUser.FullName = newFullName;
                currentUser.Email = newEmail;
            }
            usersHome.ShowThongTinCanhan();
        }
    }
}
