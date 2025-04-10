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
    public partial class AdminHome: Form
    {
        private User _user;
        public AdminHome()
        {
            InitializeComponent();
        }
        public AdminHome(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void btnquanlytaikhoan_Click(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadUserData();
        }

        private void ConfigureDataGridView()
        {
            dataGridViewUser.Columns.Clear();
            dataGridViewUser.Columns.Add("UserId", "ID Người Dùng");
            dataGridViewUser.Columns.Add("UserName", "Tên Đăng Nhập");
            dataGridViewUser.Columns.Add("Email", "Email");
            dataGridViewUser.Columns.Add("UserRole", "Vai Trò");
            dataGridViewUser.Columns.Add("Status", "Trạng Thái");
        }
        private void LoadUserData()
        {
            try
            {
                UserDAO userDAO = new UserDAO();
                List<User> users = userDAO.GetAllUsers();

                dataGridViewUser.Rows.Clear(); 

                if (users == null || users.Count == 0)
                {
                    MessageBox.Show("Không có người dùng nào được tìm thấy.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var userOnly = users.Where(u => u.UserRole == "USER").ToList();
                foreach (var user in userOnly)
                {
                    int rowIndex = dataGridViewUser.Rows.Add();
                    DataGridViewRow newRow = dataGridViewUser.Rows[rowIndex];

                    newRow.Cells["UserId"].Value = user.Id;
                    newRow.Cells["UserName"].Value = user.UserName;
                    newRow.Cells["Email"].Value = user.Email;
                    newRow.Cells["UserRole"].Value = user.UserRole;
                    newRow.Cells["Status"].Value = user.Status ? "Sẵn sàng" : "Vô hiệu hoá";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách người dùng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void setStatus_Click(object sender, EventArgs e)
        {
            try
            {
                UserDAO userDAO = new UserDAO();

                int userId = int.Parse(txtUserId.Text);
                bool status = rdActive.Checked ? true : false;
                string result = userDAO.UpdateUserStatus(userId, status);

                if (result == "Success")
                {
                    MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (!status)
                    {
                        MessageBox.Show("Tài khoản đã bị vô hiệu hóa. Người dùng không thể đăng nhập.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    LoadUserData();
                }
                else
                {
                    MessageBox.Show("Cập nhật trạng thái thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void dataGridViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewUser.Rows[e.RowIndex];
                txtUserId.Text = selectedRow.Cells["UserId"].Value?.ToString() ?? "";
                txtName.Text = selectedRow.Cells["UserName"].Value?.ToString() ?? "";
                var statusObj = selectedRow.Cells["Status"].Value;
                bool status = false;

                if (statusObj != null)
                {
                    bool.TryParse(statusObj.ToString(), out status);
                }

                // Set radio buttons
                rdActive.Checked = !status;
                rdInActive.Checked = status;
            }
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
                _user = null;

                // Hiển thị lại Home
                Home home = new Home();
                home.Show();

                this.Hide();
            }
        }


    }
}
