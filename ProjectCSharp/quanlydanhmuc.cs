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
            string type = rdThu.Checked ? "IMCOME" : "EXPENSE";
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
            TransactionCategoryDAO categoryDAO = new TransactionCategoryDAO();
            List<TransactionCategory> categories = categoryDAO.GetCategoriesByUserId(userId);

            // Xóa các hàng cũ trong DataGridView trước khi thêm mới
            dataGridViewquanlydanhmuc.Rows.Clear();

            // Thêm từng hàng vào DataGridView
            foreach (var category in categories)
            {
                int rowIndex = dataGridViewquanlydanhmuc.Rows.Add(); // Thêm hàng mới
                DataGridViewRow newRow = dataGridViewquanlydanhmuc.Rows[rowIndex];

                // Gán giá trị cho từng cột
                newRow.Cells["Id"].Value = category.Id;
                newRow.Cells["Name"].Value = category.Name;
                newRow.Cells["Description"].Value = category.Description;
                newRow.Cells["Type"].Value = category.Type;
                newRow.Cells["CreatedDate"].Value = category.CreatedDate;
            }
        }
        private void quanlydanhmuc_Load(object sender, EventArgs e)
        {
            LoadCategories(currentUser.Id);
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
    }
}
