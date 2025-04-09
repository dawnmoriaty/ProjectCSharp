using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectCSharp.DAO;
using ProjectCSharp.Model;
using System.Management;
using System.Xml.Linq;

namespace ProjectCSharp
{
    public partial class quanlydanhmuc: UserControl
    {
        private int hiddenCategoryId;
        private User currentUser;
        private UsersHome usersHome;
        public quanlydanhmuc(User user, UsersHome usersHome)
        {
            InitializeComponent();
            this.currentUser = user;
            this.usersHome = usersHome;
        }
        public quanlydanhmuc()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string name = txtTendanhmuc.Text.Trim();
            string description = txtMota.Text.Trim();
            string type = rdThu.Checked ? "INCOME" : "EXPENSE";
            int userId = currentUser.Id;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Tên danh mục không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Mô tả không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // service
            TransactionCategoryDAO categoryDAO = new TransactionCategoryDAO();
            string result = categoryDAO.CreateCategory(userId, name, description, type);
            MessageBox.Show(result, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // clear form
            btnClear_Click(sender, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTendanhmuc.Clear();
            txtMota.Clear();
            rdThu.Checked = false;
            rdChi.Checked = false;
        }

        private void thongtindanhmuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadCategories(int userId)
        {
            try
            {
                // Create an instance of DAO and fetch categories
                TransactionCategoryDAO categoryDAO = new TransactionCategoryDAO();
                List<TransactionCategory> categories = categoryDAO.GetCategoriesByUserId(userId);

                // Check if categories list is null or empty
                if (categories == null || categories.Count == 0)
                {
                    MessageBox.Show("No categories found for the specified user.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Configure DataGridView columns dynamically if not already configured
                if (dataGridViewquanlydanhmuc.Columns.Count == 0)
                {
                    dataGridViewquanlydanhmuc.Columns.Add("Id", "ID");
                    dataGridViewquanlydanhmuc.Columns.Add("Name", "Name");
                    dataGridViewquanlydanhmuc.Columns.Add("Description", "Description");
                    dataGridViewquanlydanhmuc.Columns.Add("Type", "Type");
                    dataGridViewquanlydanhmuc.Columns.Add("CreatedDate", "Created Date");
                }

                // Clear existing rows in the DataGridView
                dataGridViewquanlydanhmuc.Rows.Clear();

                // Add rows to the DataGridView
                foreach (var category in categories)
                {
                    int rowIndex = dataGridViewquanlydanhmuc.Rows.Add(); // Add new row
                    var row = dataGridViewquanlydanhmuc.Rows[rowIndex];

                    row.Cells["Id"].Value = category.Id;
                    row.Cells["Name"].Value = category.Name;
                    row.Cells["Description"].Value = category.Description;
                    row.Cells["Type"].Value = category.Type;
                    row.Cells["CreatedDate"].Value = category.CreatedDate.ToString("yyyy-MM-dd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void quanlydanhmuc_Load(object sender, EventArgs e)
        {
            
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            int categoryId = hiddenCategoryId;
            string name = txtTendanhmuc.Text.Trim();
            string description = txtMota.Text.Trim();
            string type = rdThu.Checked ? "INCOME" : "EXPENSE"; // Lấy type từ radio button

            // Tạo thể hiện của DAO
            TransactionCategoryDAO categoryDAO = new TransactionCategoryDAO();

            // Gọi phương thức UpdateCategory
            string resultMessage = categoryDAO.UpdateCategory(currentUser.Id, categoryId, name, description, type);
            MessageBox.Show(resultMessage);
            MessageBox.Show(resultMessage);
        }

        private void dataGridViewquanlydanhmuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu hàng hợp lệ
            {
                // Lấy thông tin từ hàng đã chọn
                var selectedRow = dataGridViewquanlydanhmuc.Rows[e.RowIndex];
                int id = (int)selectedRow.Cells["Id"].Value;
                string name = selectedRow.Cells["Name"].Value.ToString();
                string description = selectedRow.Cells["Description"].Value.ToString();
                string type = selectedRow.Cells["Type"].Value.ToString();

                // Gán dữ liệu vào các trường trong form tạo mới danh mục
                hiddenCategoryId = id; // Lưu ID danh mục vào biến ẩn
                txtTendanhmuc.Text = name;
                txtMota.Text = description;
                if (type.Equals("INCOME", StringComparison.OrdinalIgnoreCase))
                {
                    rdThu.Checked = true; // Chọn rdThu nếu type là INCOME
                    rdChi.Checked = false; // Đảm bảo rdChi không được chọn
                }
                else if (type.Equals("EXPENSE", StringComparison.OrdinalIgnoreCase))
                {
                    rdChi.Checked = true; // Chọn rdChi nếu type là EXPENSE
                    rdThu.Checked = false; // Đảm bảo rdThu không được chọn
                }
            }
        }

        private void bntLoadDulieu_Click(object sender, EventArgs e)
        {
            LoadCategories(currentUser.Id);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int categoryId = hiddenCategoryId; 
            TransactionCategoryDAO categoryDAO = new TransactionCategoryDAO();
            string resultMessage = categoryDAO.DeleteCategory(currentUser.Id, categoryId);
            MessageBox.Show(resultMessage);
        }
    }
}
