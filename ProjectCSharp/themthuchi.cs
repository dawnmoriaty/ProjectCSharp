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
        private void LoadTransactions(string type = null)
        {
            try
            {
                DGVthuchi.DataSource = null;
                DGVthuchi.Columns.Clear();

                // Tạo các cột
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

                // Lấy danh sách giao dịch
                List<Transaction> transactions = transactionDAO.GetTransactionsByUserId(currentUser.Id);
                if (transactions == null || transactions.Count == 0)
                {
                    MessageBox.Show("Không có giao dịch nào cho người dùng này.");
                    return;
                }

                // Tải danh mục
                if (type != null)
                {
                    LoadCategories(type); 
                }
                else
                {
                    LoadCategories(); 
                }

                // Lọc giao dịch dựa trên danh mục đã tải
                var filteredTransactions = transactions.Where(t => category.Any(c => c.Item1 == t.CategoryId)).ToList();

                if (filteredTransactions.Count == 0)
                {
                    MessageBox.Show($"Không có giao dịch nào thuộc danh mục đã tải.");
                    return;
                }

                // Chuẩn bị dữ liệu hiển thị
                var displayTransactions = filteredTransactions.Select(t => new
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
        private void btnHienthithu_Click(object sender, EventArgs e)
        {
            LoadTransactions("INCOME");
        }

        private void btnhienthichitien_Click(object sender, EventArgs e)
        {
            LoadTransactions("EXPENSE");
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
            try
            {
                if (selectedTransactionId == 0)
                {
                    MessageBox.Show("Vui lòng chọn một giao dịch để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal amountValue;
                if (!decimal.TryParse(amount.Text, out amountValue))
                {
                    MessageBox.Show("Số tiền không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cbDanhmuc.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn danh mục!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int categoryId = category[cbDanhmuc.SelectedIndex].Item1;
                int budgetId = budgetDAO.GetBudgetIdByUserId(currentUser.Id).Value;
                string descr = description.Text;

                bool result = transactionDAO.UpdateTransaction(selectedTransactionId, amountValue, categoryId, budgetId, descr);
                if (result)
                {
                    MessageBox.Show("Cập nhật giao dịch thành công!");
                    btnLoaddulieu_Click(sender, e);
                    btnClear_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Cập nhật giao dịch thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoaddulieu_Click(object sender, EventArgs e)
        {
            LoadTransactions();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem đã chọn giao dịch chưa
                if (selectedTransactionId == 0)
                {
                    MessageBox.Show("Vui lòng chọn một giao dịch để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult confirm = MessageBox.Show($"Bạn có chắc muốn xóa giao dịch ID: {selectedTransactionId}?",
                                                      "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                {
                    return; 
                }

                // Gọi DAO để xóa giao dịch
                bool result = transactionDAO.DeleteTransaction(selectedTransactionId);
                if (result)
                {
                    MessageBox.Show("Xóa giao dịch thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLoaddulieu_Click(sender, e); 
                    btnClear_Click(sender, e); 
                }
                else
                {
                    MessageBox.Show("Xóa giao dịch thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void themthuchi_Load(object sender, EventArgs e)
        {
            LoadTransactions();
        }
    }
}
