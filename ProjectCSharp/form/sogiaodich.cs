using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectCSharp;
using ProjectCSharp.DAO;
using ProjectCSharp.Model;

namespace ProjectCSharp
{
    public partial class sogiaodich : UserControl
    {
        private User _user;
        private static sogiaodich _instance;

        public static sogiaodich Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new sogiaodich();
                return _instance;
            }
        }
        public sogiaodich(User user)
        {
            InitializeComponent();
            _user = user;
            
            // Lấy thông tin ngân sách và hiển thị số dư
            LoadBudgetInfo();
        }

        public sogiaodich()
        {
        }

        private void btnPresent_Click(object sender, EventArgs e)
        {
            // Hiện thị giao dịch tháng hiện tại
            DateTime today = DateTime.Now;
            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            
            LoadTransactions(startOfMonth, endOfMonth);
        }

        private void btnFuture_Click(object sender, EventArgs e)
        {
            // Hiện thị giao dịch tháng trong tương lai
            DateTime today = DateTime.Now;
            DateTime startOfNextMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1);
            DateTime endOfNextMonth = startOfNextMonth.AddMonths(1).AddDays(-1);
            
            LoadTransactions(startOfNextMonth, endOfNextMonth);
        }

        private void btnPast_Click(object sender, EventArgs e)
        {
            // Hiện thị giao dịch tháng trong quá khứ
            DateTime today = DateTime.Now;
            DateTime startOfLastMonth = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
            DateTime endOfLastMonth = startOfLastMonth.AddMonths(1).AddDays(-1);
            
            LoadTransactions(startOfLastMonth, endOfLastMonth);
        }

        private void LoadTransactions(DateTime fromDate, DateTime toDate)
        {
            try
            {
                // Lấy dữ liệu giao dịch từ TransactionDAO
                TransactionDAO transactionDAO = new TransactionDAO();
                List<Transaction> transactions = transactionDAO.GetTransactionsAsync(_user.Id, fromDate, toDate).Result;
                
                // Xóa dữ liệu cũ trong DataGridView
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                
                // Thêm các cột vào DataGridView
                dataGridView1.Columns.Add("Id", "ID");
                dataGridView1.Columns.Add("Amount", "Số tiền");
                dataGridView1.Columns.Add("Category", "Danh mục");
                dataGridView1.Columns.Add("Date", "Ngày");
                dataGridView1.Columns.Add("Description", "Mô tả");
                
                // Thiết lập thuộc tính cho các cột
                dataGridView1.Columns["Id"].Width = 50;
                dataGridView1.Columns["Amount"].Width = 120;
                dataGridView1.Columns["Category"].Width = 150;
                dataGridView1.Columns["Date"].Width = 100;
                dataGridView1.Columns["Description"].Width = 200;
                
                // Ẩn cột ID
                dataGridView1.Columns["Id"].Visible = false;
                
                if (transactions != null && transactions.Count > 0)
                {
                    foreach (var transaction in transactions)
                    {
                        // Lấy tên category
                        TransactionCategoryDAO categoryDAO = new TransactionCategoryDAO();
                        TransactionCategory category = categoryDAO.GetCategoryById(transaction.CategoryId);
                        string categoryName = category != null ? category.Name : "Không xác định";
                        
                        // Thêm dữ liệu vào DataGridView
                        dataGridView1.Rows.Add(
                            transaction.Id,
                            transaction.Amount.ToString("N0") + " VND",
                            categoryName,
                            transaction.TransactionDate.ToString("dd/MM/yyyy"),
                            transaction.Description
                        );
                    }
                }
                else
                {
                    MessageBox.Show("Không có giao dịch nào trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            BaoCao baoCaoForm = new BaoCao(_user); 
            baoCaoForm.Show();
            this.Hide();
        }

        private void txtWalletname_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadBudgetInfo()
        {
            try
            {
                // Lấy thông tin ngân sách từ BudgetDAO
                BudgetDAO budgetDAO = new BudgetDAO();
                Budget budget = budgetDAO.GetBudgetByUserId(_user.Id);
                
                if (budget != null)
                {
                    // Hiển thị số dư trong txtSodu
                    txtSodu.Text = budget.Amount.ToString("N0") + " VND";
                    
                }
                else
                {
                    txtSodu.Text = "0 VND";
                    MessageBox.Show("Bạn chưa có ngân sách nào. Vui lòng tạo ngân sách trước khi sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSodu.Text = "0 VND";
            }
        }
    }
}
