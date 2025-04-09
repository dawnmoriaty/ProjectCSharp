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
        private void LoadCategories(string type)
        {
            TransactionCategoryDAO transactionCategoryDAO = new TransactionCategoryDAO();
            var categoryNames = transactionCategoryDAO.GetCategoryNames(currentUser.Id, type);
            category = categoryNames;
            listdanhmuc.Items.Clear();
            foreach (var category in categoryNames)
            {
                listdanhmuc.Items.Add(category.Item2);
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
            int categoryId = category[listdanhmuc.SelectedIndex].Item1; // Lấy ID danh mục từ danh sách
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

        private void description_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
