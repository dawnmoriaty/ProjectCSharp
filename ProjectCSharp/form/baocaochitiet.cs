using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ProjectCSharp;
using ProjectCSharp.DAO;
using ProjectCSharp.Model;

namespace ProjectCSharp
{

    public partial class baocaochitiet : UserControl
    {
        private User _user;
        private readonly TransactionDAO _transactionDao;
        public baocaochitiet(User user)
        {
            InitializeComponent();
            _user = user;
            _transactionDao = new TransactionDAO();
            LoadDefaultData();
        }
        private async void LoadDefaultData()
        {
            DateTime fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime toDate = DateTime.Now;

            await DisplayIncomeChart(fromDate, toDate);
            await DisplayExpenseChart(fromDate, toDate);
            await UpdateStatistics(fromDate, toDate);
        }
        private async Task DisplayIncomeChart(DateTime fromDate, DateTime toDate)
        {
            DataTable revenueData = await _transactionDao.GetRevenueByCategoryAsync(_user.Id, fromDate, toDate);

            chart1.Series.Clear();
            var series = new Series("Thu nhập")
            {
                ChartType = SeriesChartType.Pie
            };
            chart1.Legends.Clear();

            Legend legendThu = new Legend("LegendThu")
            {
                Title = "Danh mục thu nhập",
                Docking = Docking.Right,
                Alignment = StringAlignment.Center
            };
            chart1.Legends.Add(legendThu);

            decimal totalIncome = revenueData.AsEnumerable()
            .Sum(row => row.Field<decimal>("Total"));

            foreach (DataRow row in revenueData.Rows)
            {
                string categoryName = row["CategoryName"].ToString();
                decimal categoryValue = row.Field<decimal>("Total");
                double percentage = (double)(categoryValue / totalIncome) * 100;

                var point = new DataPoint
                {
                    AxisLabel = categoryName,
                    Label = $"{percentage:F2}%"
                };
                point.SetValueY(categoryValue);
                point.LegendText = categoryName;
                series.Points.Add(point);
            }

            chart1.Series.Add(series);
        }
        private async Task UpdateStatistics(DateTime fromDate, DateTime toDate)
        {
            DataTable incomeData = await _transactionDao.GetIncomeByDateAsync(_user.Id, fromDate, toDate);

            decimal totalIncome = incomeData.AsEnumerable()
                .Sum(row => row.Field<decimal>("Income"));

            txtTong.Text = $"{Math.Round(totalIncome)} VND";

            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            txtTrungbinh.Text = $"{Math.Round(totalIncome / daysInMonth)} VND";

            dataGridView1.DataSource = incomeData;
        }
        private async Task DisplayExpenseChart(DateTime fromDate, DateTime toDate)
        {
            DataTable expenseData = await _transactionDao.GetExpenseByCategoryAsync(_user.Id, fromDate, toDate);

            chart1.Series.Clear();
            var series = new Series("Chi tiêu")
            {
                ChartType = SeriesChartType.Pie
            };

            chart1.Legends.Clear();

            Legend legendChi = new Legend("LegendChi")
            {
                Title = "Danh mục chi tiêu",
                Docking = Docking.Right,
                Alignment = StringAlignment.Center
            };
            chart1.Legends.Add(legendChi);

            decimal totalExpense = expenseData.AsEnumerable()
                .Sum(row => row.Field<decimal>("Total"));
            series.ChartType = SeriesChartType.Pie;

            foreach (DataRow row in expenseData.Rows)
            {
                string categoryName = row["CategoryName"].ToString();
                decimal categoryValue = row.Field<decimal>("Total");
                double percentage = (double)(categoryValue / totalExpense) * 100;

                var point = new DataPoint
                {
                    AxisLabel = categoryName,
                    Label = $"{percentage:F2}%"
                };
                point.SetValueY(categoryValue);
                point.LegendText = categoryName;
                series.Points.Add(point);
            }

            chart1.Series.Add(series);
        }

        private async Task UpdateExpenseStatistics(DateTime fromDate, DateTime toDate)
        {
            DataTable expenseData = await _transactionDao.GetIncomeByDateAsync(_user.Id, fromDate, toDate);

            decimal totalExpense = expenseData.AsEnumerable()
                .Sum(row => row.Field<decimal>("Expense"));

            txtTong.Text = $"{Math.Round(totalExpense)} VND";

            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            txtTrungbinh.Text = $"{Math.Round(totalExpense / daysInMonth)} VND";
            dataGridView1.DataSource = expenseData;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            var parentForm = this.Parent as Form;
            if (parentForm != null)
            {
                foreach (Control control in parentForm.Controls)
                {
                    control.Visible = true;
                }
                parentForm.Controls.Remove(this);
            }
        }

        private async void btnThu_Click(object sender, EventArgs e)
        {
            DateTime fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime toDate = DateTime.Now;

            await DisplayIncomeChart(fromDate, toDate);
            await UpdateStatistics(fromDate, toDate);
        }

        private async void btnChi_Click(object sender, EventArgs e)
        {
            DateTime fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime toDate = DateTime.Now;

            await DisplayExpenseChart(fromDate, toDate);
            await UpdateExpenseStatistics(fromDate, toDate);
        }
    }
}