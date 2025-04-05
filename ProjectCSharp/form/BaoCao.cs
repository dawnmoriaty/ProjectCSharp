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
    public partial class BaoCao: Form
    {
        private readonly User _user;
        private readonly TransactionDAO transactionService;
        private System.Windows.Forms.Timer autoUpdateTimer;

        public BaoCao(User userInfo)
        {
            InitializeComponent();
            this._user = userInfo;
            transactionService = new TransactionDAO();
            this.tableLayoutPanel.Dock = DockStyle.Fill;
            this.plotThuNhapDong.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.plotKhoanThu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            this.plotKhoanChi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            this.headerPanel.Dock = DockStyle.Top;
            this.filterPanel.Dock = DockStyle.Top;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SetupAutoUpdate();
        }

        private void btnBackToGiaoDich_Click(object sender, EventArgs e)
        {
            sogiaodich giaoDichForm = new sogiaodich();
            giaoDichForm.Show();
            this.Close();
        }

        private async void btnLoadData_Click(object sender, EventArgs e)
        {
            await LoadChartData();
        }
        private void SetupAutoUpdate()
        {
            var timer = new System.Windows.Forms.Timer
            {
                Interval = 3600000
            };
            timer.Tick += async (s, e) => await LoadChartData();
            timer.Start();
        }
        private async Task LoadChartData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var thuNhapData = await transactionService.GetIncomeByDateAsync(
                    _user.Id,
                    dtpFromDate.Value,
                    dtpToDate.Value.AddDays(1).AddSeconds(-1)
                );

                var khoanThuData = await transactionService.GetRevenueByCategoryAsync(
                    _user.Id,
                    dtpFromDate.Value,
                    dtpToDate.Value.AddDays(1).AddSeconds(-1)
                );

                var khoanChiData = await transactionService.GetExpenseByCategoryAsync(
                    _user.Id,
                    dtpFromDate.Value,
                    dtpToDate.Value.AddDays(1).AddSeconds(-1)
                );

                UpdateColumnChart(thuNhapData);
                UpdateRevenueChart(khoanThuData);
                UpdateExpenseChart(khoanChiData);

                lblLastUpdate.Text = $" Cập nhật lúc: {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void UpdateColumnChart(DataTable data)
        {
            plotThuNhapDong.Series.Clear();
            plotThuNhapDong.ChartAreas.Clear();

            if (data.Rows.Count == 0)
            {
                Title title = new Title("Không có dữ liệu trong khoảng thời gian này", Docking.Top, new Font("Arial", 9, FontStyle.Bold), Color.Red);
                plotThuNhapDong.Titles.Clear();
                plotThuNhapDong.Titles.Add(title);
                plotThuNhapDong.Refresh();
                return;
            }

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.LabelStyle.Angle = -45;

            plotThuNhapDong.ChartAreas.Add(chartArea);

            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.MinorGrid.Enabled = false;
            chartArea.AxisX.LineColor = Color.LightGray;
            chartArea.AxisX.MajorTickMark.LineColor = Color.LightGray;

            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MinorGrid.Enabled = false;
            chartArea.AxisY.LineColor = Color.LightGray;
            chartArea.AxisY.MajorTickMark.LineColor = Color.LightGray;

            chartArea.AxisX.LabelStyle.Font = new Font("Arial", 7, FontStyle.Regular);
            chartArea.AxisY.LabelStyle.Font = new Font("Arial", 7, FontStyle.Regular);


            double[] incomes = data.AsEnumerable().Select(r => Convert.ToDouble(r["Income"])).ToArray();
            double[] expenses = data.AsEnumerable().Select(r => Convert.ToDouble(r["Expense"]) * -1).ToArray();
            string[] labels = data.AsEnumerable()
                .Select(r => Convert.ToDateTime(r["Date"]).ToString("dd/MM"))
                .ToArray();

            double totalIncome = incomes.Sum();
            double totalExpense = expenses.Sum();

            plotThuNhapDong.Legends.Clear();
            Legend legend = new Legend("Legend");
            plotThuNhapDong.Legends.Add(legend);

            Series incomeSeries = new Series($"Thu nhập ({totalIncome:N0} đ)")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(30, 116, 176),
                IsValueShownAsLabel = false
            };

            Series expenseSeries = new Series($"Chi tiêu ({totalExpense:N0} đ)")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(206, 92, 91),
                IsValueShownAsLabel = false
            };

            for (int i = 0; i < incomes.Length; i++)
            {
                incomeSeries.Points.AddXY(labels[i], incomes[i]);
                expenseSeries.Points.AddXY(labels[i], expenses[i]);

                if (incomes[i] != 0)
                {
                    incomeSeries.Points[i].Label = incomes[i].ToString("N0") + " đ";
                    incomeSeries.Points[i].Font = new Font("Arial", 6); 
                }

                if (expenses[i] != 0)
                {
                    expenseSeries.Points[i].Label = expenses[i].ToString("N0") + " đ";
                    expenseSeries.Points[i].Font = new Font("Arial", 6); 
                }
            }

            plotThuNhapDong.Series.Add(incomeSeries);
            plotThuNhapDong.Series.Add(expenseSeries);

            plotThuNhapDong.Titles.Clear();
            plotThuNhapDong.Titles.Add(new Title($"Thu nhập từ {dtpFromDate.Value:dd/MM/yyyy} đến {dtpToDate.Value:dd/MM/yyyy}",
                Docking.Top, new Font("Arial", 9, FontStyle.Bold), Color.Black));

            plotThuNhapDong.ChartAreas[0].AxisY.Title = "VNĐ";
            plotThuNhapDong.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 9, FontStyle.Bold);
            plotThuNhapDong.ChartAreas[0].AxisX.Title = "Ngày";
            plotThuNhapDong.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 9, FontStyle.Bold);

            plotThuNhapDong.Refresh();
        }

        private void UpdateRevenueChart(DataTable data)
        {
            plotKhoanThu.Series.Clear();
            plotKhoanThu.ChartAreas.Clear();
            plotKhoanThu.Titles.Clear();

            if (data.Rows.Count == 0)
            {
                Title title = new Title("Không có dữ liệu khoản thu", Docking.Top, new Font("Arial", 9, FontStyle.Bold), Color.Red);
                plotKhoanThu.Titles.Add(title);
                plotKhoanThu.Refresh();
                return;
            }

            double[] values = data.AsEnumerable()
                .Select(r => Convert.ToDouble(r["Total"]))
                .ToArray();

            string[] labels = data.AsEnumerable()
                .Select(r => $"{Convert.ToDouble(r["Total"]):N0} đ")
                .ToArray();

            plotKhoanThu.Legends.Clear();
            Legend legendThu = new Legend("Legend");
            plotKhoanThu.Legends.Add(legendThu);

            ChartArea chartArea = new ChartArea();
            plotKhoanThu.ChartAreas.Add(chartArea);

            Series pieSeries = new Series("Khoản thu")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true 
            };

            for (int i = 0; i < values.Length; i++)
            {
                DataPoint point = new DataPoint();
                point.SetValueXY(labels[i], values[i]); 
                point.Label = $"({values[i] / values.Sum() * 100:0.0}%)";
                string categoryName = data.Rows[i]["CategoryName"].ToString();
                point.LegendText = $"{categoryName} ({values[i]:N0} đ)";
                point.Font = new Font("Arial", 6);
                pieSeries.Points.Add(point);
            }

            plotKhoanThu.Series.Add(pieSeries);

            plotKhoanThu.Titles.Add(new Title(
                $"Khoản thu theo danh mục\n{dtpFromDate.Value:dd/MM/yyyy} - {dtpToDate.Value:dd/MM/yyyy}",
                Docking.Top, new Font("Arial", 9, FontStyle.Bold), Color.Black
            ));

            plotKhoanThu.Refresh();

        }

        private void UpdateExpenseChart(DataTable data)
        {
            plotKhoanChi.Series.Clear();
            plotKhoanChi.ChartAreas.Clear();
            plotKhoanChi.Titles.Clear();

            if (data.Rows.Count == 0)
            {
                Title title = new Title("Không có dữ liệu khoản chi", Docking.Top, new Font("Arial", 9, FontStyle.Bold), Color.Red);
                plotKhoanChi.Titles.Add(title);
                plotKhoanChi.Refresh();
                return;
            }

            double[] values = data.AsEnumerable()
                .Select(r => Convert.ToDouble(r["Total"]))
                .ToArray();

            string[] labels = data.AsEnumerable()
                .Select(r => $"{Convert.ToDouble(r["Total"]):N0} đ")
                .ToArray();

            ChartArea chartArea = new ChartArea();
            plotKhoanChi.ChartAreas.Add(chartArea);

            Series pieSeries = new Series("Khoản chi")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true 
            };

            for (int i = 0; i < values.Length; i++)
            {
                DataPoint point = new DataPoint();
                point.SetValueXY(labels[i], values[i]); 
                point.Label = $"({values[i] / values.Sum() * 100:0.0}%)";
                point.Font = new Font("Arial", 6);
                pieSeries.Points.Add(point);
            }

            plotKhoanChi.Series.Add(pieSeries);

            plotKhoanChi.Titles.Add(new Title(
                $"Khoản chi theo danh mục\n{dtpFromDate.Value:dd/MM/yyyy} - {dtpToDate.Value:dd/MM/yyyy}",
                Docking.Top, new Font("Arial", 9, FontStyle.Bold), Color.Black
            ));

            plotKhoanChi.Refresh();

        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            
            baocaochitiet baoCaoChiTiet = new baocaochitiet(_user);  

            ShowUserControl(baoCaoChiTiet);
        }
        public void ShowUserControl(UserControl uc)
        {
            foreach (Control control in this.Controls)
            {
                control.Visible = false;
            }
            if (!this.Controls.Contains(uc))
            {
                uc.Dock = DockStyle.Fill;
                this.Controls.Add(uc);
            }

            uc.Visible = true;
            uc.BringToFront();
        }
        private async void BaoCao_Load(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                dtpFromDate.Value = DateTime.Now.AddDays(-30);
                dtpToDate.Value = DateTime.Now;
            });

            await LoadChartData();
        }
    }
}
