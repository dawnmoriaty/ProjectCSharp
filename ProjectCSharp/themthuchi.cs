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
    public partial class themthuchi: UserControl
    {
        private User currentUser;
        private UsersHome usersHome;
        private int selectedTransactionId;
        private BudgetDAO budgetDAO = new BudgetDAO();
        private TransactionDAO transactionDAO = new TransactionDAO();

        List<Tuple<int, string>> category;
        public themthuchi()
        {
            InitializeComponent();
        }
        public themthuchi(User user , UsersHome usersHome)
        {
            InitializeComponent();
            this.usersHome = usersHome;
            this.currentUser = user;
        }
        private void LoadCategories()
        {
            TransactionCategoryDAO transactionCategoryDAO = new TransactionCategoryDAO();
            var categoryNames = transactionCategoryDAO.GetCategoryNames(currentUser.Id);
            category = categoryNames;
            cbDanhmuc.Items.Clear();
            foreach (var cat in categoryNames)
            {
                cbDanhmuc.Items.Add(cat.Item2);
            }
        }
        private void LoadCategories(string type)
        {
            TransactionCategoryDAO transactionCategoryDAO = new TransactionCategoryDAO();
            var categoryNames = transactionCategoryDAO.GetCategoryNames(currentUser.Id, type);
            category = categoryNames;
            cbDanhmuc.Items.Clear();
            foreach (var category in categoryNames)
            {
                cbDanhmuc.Items.Add(category.Item2);
            }
        }
        private void btnHienthithu_Click(object sender, EventArgs e)
        {
            LoadCategories("INCOME");
        }

        private void btnhienthichitien_Click(object sender, EventArgs e)
        {
            LoadCategories("EXPENSE");
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            int budgetId = budgetDAO.GetBudgetIdByUserId(currentUser.Id).Value;
            int categoryId = category[cbDanhmuc.SelectedIndex].Item1; // Lấy ID danh mục từ danh sách
            string descr = description.Text;
            decimal amountValue = Convert.ToDecimal(amount.Text);

            // Fix: Pass the correct arguments to the CreateTransaction method
            bool result = transactionDAO.CreateTransaction(amountValue, categoryId, budgetId, descr, currentUser.Id);
        }

        private void amount_TextChanged(object sender, EventArgs e)
        {
            decimal amountValue;
            if (decimal.TryParse(amount.Text, out amountValue))
            {
                // Sử dụng biến amountValue ở đây
                Console.WriteLine("Giá trị hợp lệ: " + amountValue);
            }
            else
            {
                // Thông báo lỗi nếu cần
                Console.WriteLine("Giá trị không hợp lệ");
            }
        }

        

        private void btnClear_Click(object sender, EventArgs e)
        {
            amount.Clear();
            description.Clear();
            cbDanhmuc.SelectedIndex = -1; // Đặt lại chỉ số danh mục
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {

        }

        private void btnLoaddulieu_Click(object sender, EventArgs e)
        {
            try
            {
                DGVthuchi.DataSource = null; 
                DGVthuchi.Columns.Clear();
                DGVthuchi.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Id", 
                    HeaderText = "ID",
                    Name = "Id"
                });
                DGVthuchi.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Amount",
                    HeaderText = "Số tiền",
                    Name = "Amount"
                });
                DGVthuchi.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CategoryName", 
                    HeaderText = "Danh mục",
                    Name = "CategoryName"
                });
                DGVthuchi.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Description",
                    HeaderText = "Mô tả",
                    Name = "Description"
                });
                DGVthuchi.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TransactionDate",
                    HeaderText = "Ngày giao dịch",
                    Name = "TransactionDate",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } 
                });
                DGVthuchi.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "BudgetId",
                    HeaderText = "Ngân sách ID",
                    Name = "BudgetId"
                });
                DGVthuchi.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "UserId",
                    HeaderText = "Người dùng ID",
                    Name = "UserId"
                });
                DGVthuchi.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CategoryId",
                    HeaderText = "Category ID",
                    Name = "CategoryId"
                });
                List<Transaction> transactions = transactionDAO.GetTransactionsByUserId(currentUser.Id);
                if (transactions == null || transactions.Count == 0)
                {
                    MessageBox.Show("Không có giao dịch nào cho người dùng này.");
                    return;
                }
                if (category == null || category.Count == 0)
                {
                    LoadCategories(); 
                }
                var displayTransactions = transactions.Select(t => new
                {
                    t.Id,
                    t.Amount,
                    CategoryName = category.FirstOrDefault(c => c.Item1 == t.CategoryId)?.Item2 ?? "Không xác định",
                    t.Description,
                    t.TransactionDate,
                    t.BudgetId,
                    t.UserId,
                    t.CategoryId
                }).ToList();
                DGVthuchi.AutoGenerateColumns = false; 
                DGVthuchi.DataSource = displayTransactions;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DGVthuchi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVthuchi.Rows[e.RowIndex];
                amount.Text = row.Cells["Amount"].Value?.ToString();
                description.Text = row.Cells["Description"].Value?.ToString();
                int selectedCategoryId = Convert.ToInt32(row.Cells["CategoryId"].Value);
                for (int i = 0; i < category.Count; i++)
                {
                    if (category[i].Item1 == selectedCategoryId)
                    {
                        cbDanhmuc.SelectedIndex = i;
                        break;
                    }
                }

                selectedTransactionId = Convert.ToInt32(row.Cells["Id"].Value);
            }
        }
    }
}
