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
            listdanhmuc.Items.Clear();
            foreach (var name in categoryNames)
            {
                listdanhmuc.Items.Add(name); 
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
            
        }
    }
}
