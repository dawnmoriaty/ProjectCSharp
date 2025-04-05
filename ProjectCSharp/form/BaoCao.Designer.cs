using System.Windows.Forms;

namespace ProjectCSharp
{
    partial class BaoCao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnBackToGiaoDich = new System.Windows.Forms.Button();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.btnChiTiet = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.plotThuNhapDong = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.plotKhoanThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.plotKhoanChi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblHeader = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.filterPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plotThuNhapDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plotKhoanThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plotKhoanChi)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBackToGiaoDich
            // 
            this.btnBackToGiaoDich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(180)))), ((int)(((byte)(113)))));
            this.btnBackToGiaoDich.Location = new System.Drawing.Point(3, 3);
            this.btnBackToGiaoDich.Name = "btnBackToGiaoDich";
            this.btnBackToGiaoDich.Size = new System.Drawing.Size(96, 36);
            this.btnBackToGiaoDich.TabIndex = 0;
            this.btnBackToGiaoDich.Text = "< Quay lại";
            this.btnBackToGiaoDich.UseVisualStyleBackColor = false;
            this.btnBackToGiaoDich.Click += new System.EventHandler(this.btnBackToGiaoDich_Click);
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.lblLastUpdate);
            this.filterPanel.Controls.Add(this.btnChiTiet);
            this.filterPanel.Controls.Add(this.btnLoadData);
            this.filterPanel.Controls.Add(this.dtpToDate);
            this.filterPanel.Controls.Add(this.dtpFromDate);
            this.filterPanel.Controls.Add(this.lblTo);
            this.filterPanel.Controls.Add(this.lblFrom);
            this.filterPanel.Location = new System.Drawing.Point(12, 115);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(1154, 82);
            this.filterPanel.TabIndex = 1;
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdate.Location = new System.Drawing.Point(12, 50);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(120, 20);
            this.lblLastUpdate.TabIndex = 6;
            this.lblLastUpdate.Text = "Cập nhật lúc: ";
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(116)))), ((int)(((byte)(176)))));
            this.btnChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnChiTiet.Location = new System.Drawing.Point(982, 6);
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Size = new System.Drawing.Size(159, 37);
            this.btnChiTiet.TabIndex = 5;
            this.btnChiTiet.Text = "Xem chi tiết >>";
            this.btnChiTiet.UseVisualStyleBackColor = false;
            this.btnChiTiet.Click += new System.EventHandler(this.btnChiTiet_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(92)))), ((int)(((byte)(91)))));
            this.btnLoadData.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLoadData.Location = new System.Drawing.Point(839, 6);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(122, 36);
            this.btnLoadData.TabIndex = 4;
            this.btnLoadData.Text = "Tải dữ liệu";
            this.btnLoadData.UseVisualStyleBackColor = false;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(496, 10);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(292, 26);
            this.dtpToDate.TabIndex = 3;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(83, 10);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(303, 26);
            this.dtpFromDate.TabIndex = 2;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(413, 14);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(77, 20);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "Đến ngày";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(12, 15);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(65, 20);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Từ ngày";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.plotThuNhapDong, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.plotKhoanThu, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.plotKhoanChi, 1, 1);
            this.tableLayoutPanel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 203);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.36634F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.63366F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1154, 529);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // plotThuNhapDong
            // 
            chartArea1.Name = "ChartArea1";
            this.plotThuNhapDong.ChartAreas.Add(chartArea1);
            this.tableLayoutPanel.SetColumnSpan(this.plotThuNhapDong, 2);
            legend1.Name = "Legend1";
            this.plotThuNhapDong.Legends.Add(legend1);
            this.plotThuNhapDong.Location = new System.Drawing.Point(3, 3);
            this.plotThuNhapDong.Name = "plotThuNhapDong";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.plotThuNhapDong.Series.Add(series1);
            this.plotThuNhapDong.Size = new System.Drawing.Size(1148, 223);
            this.plotThuNhapDong.TabIndex = 0;
            this.plotThuNhapDong.Text = "chart1";
            // 
            // plotKhoanThu
            // 
            chartArea2.Name = "ChartArea1";
            this.plotKhoanThu.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.plotKhoanThu.Legends.Add(legend2);
            this.plotKhoanThu.Location = new System.Drawing.Point(3, 232);
            this.plotKhoanThu.Name = "plotKhoanThu";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.plotKhoanThu.Series.Add(series2);
            this.plotKhoanThu.Size = new System.Drawing.Size(571, 294);
            this.plotKhoanThu.TabIndex = 1;
            this.plotKhoanThu.Text = "chart2";
            // 
            // plotKhoanChi
            // 
            chartArea3.Name = "ChartArea1";
            this.plotKhoanChi.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.plotKhoanChi.Legends.Add(legend3);
            this.plotKhoanChi.Location = new System.Drawing.Point(580, 232);
            this.plotKhoanChi.Name = "plotKhoanChi";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.plotKhoanChi.Series.Add(series3);
            this.plotKhoanChi.Size = new System.Drawing.Size(571, 294);
            this.plotKhoanChi.TabIndex = 2;
            this.plotKhoanChi.Text = "chart3";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(8, 51);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(340, 37);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "BÁO CÁO THỐNG KÊ";
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(180)))), ((int)(((byte)(113)))));
            this.headerPanel.Controls.Add(this.lblHeader);
            this.headerPanel.Controls.Add(this.btnBackToGiaoDich);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1178, 100);
            this.headerPanel.TabIndex = 0;
            // 
            // BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "BaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Thống Kê";
            this.Load += new System.EventHandler(this.BaoCao_Load);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plotThuNhapDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plotKhoanThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plotKhoanChi)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBackToGiaoDich;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart plotThuNhapDong;
        private System.Windows.Forms.DataVisualization.Charting.Chart plotKhoanThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart plotKhoanChi;
        private DateTimePicker dtpToDate;
        private DateTimePicker dtpFromDate;
        private Label lblTo;
        private Label lblFrom;
        private Button btnLoadData;
        private Button btnChiTiet;
        private Label lblHeader;
        private Panel headerPanel;
        private Label lblLastUpdate;
    }
}

