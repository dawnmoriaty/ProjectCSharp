using ProjectCSharp.DAO;
using ProjectCSharp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCSharp
{
    public partial class themgiaodich : Form
    {
        private User _user;
        private UsersHome _usersHome;
        public themgiaodich(User user, UsersHome usersHome)
        {
            InitializeComponent();
            _user = user;
            _usersHome = usersHome;
            
            // Lấy dữ liệu categories và gán vào comboBox1
            LoadCategories();
            
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }

        private void LoadCategories()
        {
            try
            {
                // Lấy tất cả categories từ TransactionCategoryDAO
                TransactionCategoryDAO categoryDAO = new TransactionCategoryDAO();
                List<TransactionCategory> categories = categoryDAO.GetAllCategories();
                
                // Tạo DataSource cho comboBox1
                comboBox1.DataSource = categories;
                comboBox1.DisplayMember = "Name"; // Hiển thị tên category
                comboBox1.ValueMember = "Id";     // Giá trị là ID của category
                comboBox1.SelectedIndex = -1;     // Không chọn giá trị nào mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtSotien.Clear();
            comboBox1.SelectedIndex = -1;
        }


        private void btn0_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "0";
        }

        private void btn000_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "000";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "9";
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "+";
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "-";
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "*";
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            txtSotien.Text += "/";
        }

        private void btnPhay_Click(object sender, EventArgs e)
        {
            txtSotien.Text += ".";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtSotien.Text.Length > 0)
            {
                txtSotien.Text = txtSotien.Text.Remove(txtSotien.Text.Length - 1);
            }
        }

        private void txtSotien_TextChanged(object sender, EventArgs e)
        {
            //đây là thông tin cho Amount
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // từ TransactionCategoryDAO lấy thông tin các category ra cho người dùng lựa chọn trong combobox, chọn tên category thì sẽ lấy id category để tạo transaction
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // đây là thông tin cho transactionDate
        }

        private void Description_TextChanged(object sender, EventArgs e)
        {
            // thông tin cho description
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Tính toán và hiển thị kết quả
                var computeResult = new DataTable().Compute(txtSotien.Text, null);
                decimal amount = Convert.ToDecimal(computeResult);
                txtSotien.Text = amount.ToString();

                // Kiểm tra dữ liệu đầu vào
                if (comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn danh mục giao dịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSotien.Text))
                {
                    MessageBox.Show("Vui lòng nhập số tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy BudgetId của user
                BudgetDAO budgetDAO = new BudgetDAO();
                int? budgetId = budgetDAO.GetBudgetIdByUserId(_user.Id);
                
                if (!budgetId.HasValue)
                {
                    MessageBox.Show("Bạn chưa có ngân sách nào. Vui lòng tạo ngân sách trước khi thêm giao dịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng Transaction mới
                Transaction transaction = new Transaction
                {
                    Amount = amount,
                    CategoryId = Convert.ToInt32(comboBox1.SelectedValue),
                    BudgetId = budgetId.Value,
                    TransactionDate = dateTimePicker1.Value,
                    Description = Description.Text,
                    UserId = _user.Id
                };

                // Lưu giao dịch vào database
                TransactionDAO transactionDAO = new TransactionDAO();
                string saveResult = transactionDAO.CreateTransaction(transaction);

                if (saveResult == "success")
                {
                    MessageBox.Show("Thêm giao dịch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                    // Cập nhật lại dữ liệu trên form UsersHome
                    if (_usersHome != null)
                    {
                        // Gọi phương thức ShowSoGiaoDich để cập nhật dữ liệu
                        _usersHome.ShowSoGiaoDich();
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi: " + saveResult, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
