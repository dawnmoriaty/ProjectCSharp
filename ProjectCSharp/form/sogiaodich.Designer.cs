namespace ProjectCSharp
{
    partial class sogiaodich
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSodu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPast = new System.Windows.Forms.Button();
            this.btnPresent = new System.Windows.Forms.Button();
            this.btnFuture = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBaocao = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSodu);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1218, 100);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(703, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "VNĐ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số dư ví";
            // 
            // txtSodu
            // 
            this.txtSodu.Location = new System.Drawing.Point(547, 62);
            this.txtSodu.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSodu.Name = "txtSodu";
            this.txtSodu.ReadOnly = true;
            this.txtSodu.Size = new System.Drawing.Size(150, 26);
            this.txtSodu.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(488, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "SỔ GIAO DỊCH";
            // 
            // btnPast
            // 
            this.btnPast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnPast.Location = new System.Drawing.Point(145, 39);
            this.btnPast.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnPast.Name = "btnPast";
            this.btnPast.Size = new System.Drawing.Size(137, 45);
            this.btnPast.TabIndex = 2;
            this.btnPast.Text = "Tháng trước";
            this.btnPast.UseVisualStyleBackColor = false;
            this.btnPast.Click += new System.EventHandler(this.btnPast_Click);
            // 
            // btnPresent
            // 
            this.btnPresent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnPresent.Location = new System.Drawing.Point(547, 39);
            this.btnPresent.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnPresent.Name = "btnPresent";
            this.btnPresent.Size = new System.Drawing.Size(132, 45);
            this.btnPresent.TabIndex = 3;
            this.btnPresent.Text = "Tháng này";
            this.btnPresent.UseVisualStyleBackColor = false;
            this.btnPresent.Click += new System.EventHandler(this.btnPresent_Click);
            // 
            // btnFuture
            // 
            this.btnFuture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnFuture.Location = new System.Drawing.Point(928, 39);
            this.btnFuture.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnFuture.Name = "btnFuture";
            this.btnFuture.Size = new System.Drawing.Size(120, 45);
            this.btnFuture.TabIndex = 4;
            this.btnFuture.Text = "Tương lai";
            this.btnFuture.UseVisualStyleBackColor = false;
            this.btnFuture.Click += new System.EventHandler(this.btnFuture_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBaocao);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.btnPast);
            this.panel2.Controls.Add(this.btnFuture);
            this.panel2.Controls.Add(this.btnPresent);
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1218, 791);
            this.panel2.TabIndex = 1;
            // 
            // btnBaocao
            // 
            this.btnBaocao.Location = new System.Drawing.Point(495, 674);
            this.btnBaocao.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnBaocao.Name = "btnBaocao";
            this.btnBaocao.Size = new System.Drawing.Size(212, 42);
            this.btnBaocao.TabIndex = 7;
            this.btnBaocao.Text = "Xem báo cáo giai đoạn này";
            this.btnBaocao.UseVisualStyleBackColor = true;
            this.btnBaocao.Click += new System.EventHandler(this.btnBaocao_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(145, 145);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(903, 470);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // sogiaodich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "sogiaodich";
            this.Size = new System.Drawing.Size(1218, 891);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFuture;
        private System.Windows.Forms.Button btnPresent;
        private System.Windows.Forms.Button btnPast;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSodu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBaocao;
    }
}
