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
    public partial class homepage: UserControl
    {
        private User currentUser;
        private UsersHome usersHome;
        private TransactionDAO transactionDAO;

        public homepage()
        {
            InitializeComponent();
        }

        public homepage(User user, UsersHome usersHome)
        {
            InitializeComponent();
            this.currentUser = user;
            this.usersHome = usersHome;
            this.transactionDAO = new TransactionDAO();
            LoadTransactions();
        }

        private async void LoadTransactions()
        {
            try
            {
                // Lấy dữ liệu giao dịch thu nhập
                DataTable incomeData = await transactionDAO.GetRevenueByCategoryAsync(
                    currentUser.Id, 
                    DateTime.Now.AddMonths(-1), 
                    DateTime.Now.AddMonths(1)
                );
                dataGridView3.DataSource = incomeData;


                DataTable expenseData = await transactionDAO.GetTransactionOrderByDateAsync(
                    currentUser.Id
                );
                dataGridView1.DataSource = expenseData;

                // Cấu hình hiển thị cho DataGridView
                ConfigureDataGridView(dataGridView3);
                ConfigureDataGridView(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
        }
    }
}
