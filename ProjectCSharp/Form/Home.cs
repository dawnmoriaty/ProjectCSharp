using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectCSharp.DAO;
using ProjectCSharp.Model;
namespace ProjectCSharp
{
    public partial class Home : Form
    {
        //====================Varialbles======================
        
        public Home()
        {
            InitializeComponent();
        }
        //====================Register======================
        private void btnClearForm_Click(object sender, EventArgs e)
        {
            txtUserNameRegister.Text = "";
            txtEmailRegister.Text = "";
            txtFullNameRegister.Text = "";
            txtPasswordRegister.Text = "";
            txtUserNameRegister.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPasswordRegister.UseSystemPasswordChar = false;
            }
            else
            {
                txtPasswordRegister.UseSystemPasswordChar = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            txtUserNameRegister.Text = "";
            txtEmailRegister.Text = "";
            txtFullNameRegister.Text = "";
            txtPasswordRegister.Text = "";
            panelRegister.Visible = false;

        }

        private void btnRegisterPanel_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
            panelRegister.Visible = true;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelRegister.Visible = false;
            panelLogin.Visible=false;
        }

        // Viết Logic Sau
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ giao diện
            string username = txtUserNameRegister.Text.Trim();
            string password = txtPasswordRegister.Text.Trim();
            string fullName = txtFullNameRegister.Text.Trim();
            string email = txtEmailRegister.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin (tên đăng nhập, mật khẩu, họ tên, email, quyền hạn)!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra email hợp lệ
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ! Vui lòng kiểm tra lại.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi UserDAO để đăng ký
            UserDAO userDAO = new UserDAO();
            string result = userDAO.Register(username, password, fullName, email);

            // Xử lý kết quả đăng ký
            if (result == "Đăng ký thành công")
            {
                MessageBox.Show("Đăng ký thành công! Bạn có thể đăng nhập ngay bây giờ.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelRegister.Visible = false;
                panelLogin.Visible = true;

            }
            else
            {
                // Hiển thị thông báo lỗi từ UserDAO
                MessageBox.Show(result, "Lỗi đăng ký",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ====================Login======================
        private void btnExitLogin_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.Clear();
            txtPasswordLogin.Clear();
            txtUserNameLogin.Clear();
            panelLogin.Visible = false;
        }

        private void btnClearLogin_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.Clear();
            txtPasswordLogin.Clear();
            txtUserNameLogin.Clear();
            txtUserNameLogin.Focus();
        }

        private void btnLoginPanel_Click(object sender, EventArgs e)
        {
            panelRegister.Visible=false;
            panelLogin.Visible=true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txtPasswordLogin.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPasswordLogin.UseSystemPasswordChar = true;
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
            CheckPasswordMatch();
        }
        private void CheckPasswordMatch()
        {
            if (txtPasswordLogin.Text == txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "");
                btnLogin.Enabled = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "❌ Mật khẩu không khớp!");
                btnLogin.Enabled = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserNameLogin.Text.Trim();
            string password = txtPasswordLogin.Text.Trim();
            string selectedRole = UserRole.SelectedItem?.ToString(); // Lấy role từ ComboBox

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập, mật khẩu và vai trò!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra đăng nhập
            UserDAO userDAO = new UserDAO();
            bool isValid = userDAO.CheckLogin(username, password, selectedRole);

            if (isValid)
            {
                User user = userDAO.GetUserInfo(username);
                UsersHome usersHome = new UsersHome(user);
                usersHome.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập, mật khẩu hoặc vai trò không đúng!", "Lỗi đăng nhập",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
