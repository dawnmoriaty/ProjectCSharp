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
    public partial class danhmucgiaodich : Form
    {
        private TransactionCategoryDAO categoryDAO;
        private List<TransactionCategory> categories;

        public danhmucgiaodich()
        {
            InitializeComponent();
            categoryDAO = new TransactionCategoryDAO();
            InitializeComboBox();
            LoadCategories();
        }

        private void InitializeComboBox()
        {
            // Thêm các lựa chọn vào ComboBox
            loaiDanhMuc.Items.Add("INCOME");
            loaiDanhMuc.Items.Add("EXPENSE");
            loaiDanhMuc.SelectedIndex = -1; // Không chọn mặc định
        }

        private void LoadCategories()
        {
            try
            {
                // Lấy danh sách danh mục thu nhập
                var incomeCategories = categoryDAO.GetCategoriesByType("INCOME");
                // Lấy danh sách danh mục chi tiêu
                var expenseCategories = categoryDAO.GetCategoriesByType("EXPENSE");

                // Kết hợp cả hai loại danh mục
                categories = new List<TransactionCategory>();
                if (incomeCategories != null) categories.AddRange(incomeCategories);
                if (expenseCategories != null) categories.AddRange(expenseCategories);

                // Hiển thị lên DataGridView
                dataGridViewDanhmuc.DataSource = categories;
                dataGridViewDanhmuc.Columns["Transactions"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(TenDanhMuc.Text.Trim()))
                {
                    MessageBox.Show("Vui lòng nhập tên danh mục!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo danh mục mới
                string result = categoryDAO.CreateCategory(
                    TenDanhMuc.Text.Trim(),
                    textBox3.Text.Trim(),
                    loaiDanhMuc.SelectedItem.ToString(),
                    false
                );

                if (result.StartsWith("Tạo danh mục thành công"))
                {
                    MessageBox.Show(result, "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadCategories();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo danh mục: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewDanhmuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var selectedCategory = categories[e.RowIndex];
                    TenDanhMuc.Text = selectedCategory.Name;
                    textBox3.Text = selectedCategory.Description;
                    loaiDanhMuc.SelectedItem = selectedCategory.Type;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn danh mục: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            LoadCategories();
            ClearForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDanhmuc.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn danh mục cần sửa!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedCategory = categories[dataGridViewDanhmuc.SelectedRows[0].Index];
                string result = categoryDAO.UpdateCategory(
                    selectedCategory.Id,
                    TenDanhMuc.Text.Trim(),
                    textBox3.Text.Trim()
                );

                if (result.StartsWith("Cập nhật danh mục thành công"))
                {
                    MessageBox.Show(result, "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadCategories();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật danh mục: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDanhmuc.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn danh mục cần xóa!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedCategory = categories[dataGridViewDanhmuc.SelectedRows[0].Index];
                
                // Xác nhận trước khi xóa
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa danh mục này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    string deleteResult = categoryDAO.DeleteCategory(selectedCategory.Id);
                    if (deleteResult.StartsWith("Xóa danh mục thành công"))
                    {
                        MessageBox.Show(deleteResult, "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadCategories();
                    }
                    else
                    {
                        MessageBox.Show(deleteResult, "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa danh mục: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            TenDanhMuc.Clear();
            textBox3.Clear();
            loaiDanhMuc.SelectedIndex = -1;
            dataGridViewDanhmuc.ClearSelection();
        }

        private void TenDanhMuc_TextChanged(object sender, EventArgs e)
        {

        }

        private void loaiDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaiDanhMuc.SelectedIndex >= 0)
            {
                string selectedType = loaiDanhMuc.SelectedItem.ToString();
                // Lọc danh mục theo loại được chọn
                var filteredCategories = categories.Where(c => c.Type == selectedType).ToList();
                dataGridViewDanhmuc.DataSource = filteredCategories;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Xử lý khi thay đổi mô tả
        }
    }
}
