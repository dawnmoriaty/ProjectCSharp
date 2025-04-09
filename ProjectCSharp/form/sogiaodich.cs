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
        private TransactionDAO _transactionDAO;
        public sogiaodich()
        {
            InitializeComponent();
        }   
        public sogiaodich(User user)
        {
            InitializeComponent();
            _user = user;
            _transactionDAO = new TransactionDAO();
            
            // Khởi tạo DataGridView
            InitializeDataGridView();
            
            // Lấy thông tin ngân sách và hiển thị số dư
            LoadBudgetInfo();
            
            // Hiển thị giao dịch tháng hiện tại
            LoadCurrentMonthTransactions();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            // Thêm các cột
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                Visible = false
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                HeaderText = "Số tiền",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "Danh mục",
                Width = 150
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Date",
                HeaderText = "Ngày",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Mô tả",
                Width = 200
            });
        }

        private async void LoadCurrentMonthTransactions()
        {
            DateTime today = DateTime.Now;
            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            
            await LoadTransactions(startOfMonth, endOfMonth);
        }

        private async void btnPresent_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            
            await LoadTransactions(startOfMonth, endOfMonth);
        }

        private async void btnFuture_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            DateTime startOfNextMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1);
            DateTime endOfNextMonth = startOfNextMonth.AddMonths(1).AddDays(-1);
            
            await LoadTransactions(startOfNextMonth, endOfNextMonth);
        }

        private async void btnPast_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            DateTime startOfLastMonth = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
            DateTime endOfLastMonth = startOfLastMonth.AddMonths(1).AddDays(-1);
            
            await LoadTransactions(startOfLastMonth, endOfLastMonth);
        }

        private async Task LoadTransactions(DateTime fromDate, DateTime toDate)
        {
            try
            {
                // Hiển thị loading
                Cursor.Current = Cursors.WaitCursor;
                dataGridView1.Rows.Clear();

                // Lấy dữ liệu giao dịch
                List<Transaction> transactions = await _transactionDAO.GetTransactionsAsync(_user.Id, fromDate, toDate);

                if (transactions != null && transactions.Count > 0)
                {
                    foreach (var transaction in transactions)
                    {
                        // Thêm dữ liệu vào DataGridView
                        dataGridView1.Rows.Add(
                            transaction.Id,
                            transaction.Amount.ToString("N0") + " VND",
                            transaction.CategoryName,
                            transaction.TransactionDate.ToString("dd/MM/yyyy"),
                            transaction.Description
                        );
                    }
                }
                else
                {
                    MessageBox.Show("Không có giao dịch nào trong khoảng thời gian này!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void LoadBudgetInfo()
        {
            try
            {
                BudgetDAO budgetDAO = new BudgetDAO();
                Budget budget = budgetDAO.GetBudgetByUserId(_user.Id);

                if (budget != null)
                {
                    decimal tongthu = _transactionDAO.GetTotalIncomeAsync(_user.Id).Result;
                    decimal tongchi = _transactionDAO.GetTotalExpenseAsync(_user.Id).Result;
                    decimal sodu = budget.Amount - tongchi + tongthu;
                    txtSodu.Text = sodu.ToString("N0") + " VND";
                }
                else
                {
                    txtSodu.Text = "0 VND";
                    MessageBox.Show("Bạn chưa có ngân sách nào. Vui lòng tạo ngân sách trước khi sử dụng!", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSodu.Text = "0 VND";
            }
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            //BaoCao baoCaoForm = new BaoCao(_user);
            //baoCaoForm.Show();
            //this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
