namespace ProjectCSharp
{
    partial class AdminHome
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
            this.SideBarAdmin = new System.Windows.Forms.Panel();
            this.btnthongtincanhan = new System.Windows.Forms.Button();
            this.btnxembaocao = new System.Windows.Forms.Button();
            this.btnquanlytaikhoan = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SideBarAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SideBarAdmin
            // 
            this.SideBarAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.SideBarAdmin.Controls.Add(this.btnthongtincanhan);
            this.SideBarAdmin.Controls.Add(this.btnxembaocao);
            this.SideBarAdmin.Controls.Add(this.btnquanlytaikhoan);
            this.SideBarAdmin.Location = new System.Drawing.Point(0, 1);
            this.SideBarAdmin.Name = "SideBarAdmin";
            this.SideBarAdmin.Size = new System.Drawing.Size(269, 627);
            this.SideBarAdmin.TabIndex = 0;
            // 
            // btnthongtincanhan
            // 
            this.btnthongtincanhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnthongtincanhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthongtincanhan.ForeColor = System.Drawing.Color.White;
            this.btnthongtincanhan.Location = new System.Drawing.Point(22, 386);
            this.btnthongtincanhan.Name = "btnthongtincanhan";
            this.btnthongtincanhan.Size = new System.Drawing.Size(209, 60);
            this.btnthongtincanhan.TabIndex = 2;
            this.btnthongtincanhan.Text = "Thông tin cá nhân";
            this.btnthongtincanhan.UseVisualStyleBackColor = false;
            // 
            // btnxembaocao
            // 
            this.btnxembaocao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnxembaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxembaocao.ForeColor = System.Drawing.Color.White;
            this.btnxembaocao.Location = new System.Drawing.Point(22, 251);
            this.btnxembaocao.Name = "btnxembaocao";
            this.btnxembaocao.Size = new System.Drawing.Size(209, 60);
            this.btnxembaocao.TabIndex = 1;
            this.btnxembaocao.Text = "Xem báo cáo";
            this.btnxembaocao.UseVisualStyleBackColor = false;
            // 
            // btnquanlytaikhoan
            // 
            this.btnquanlytaikhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnquanlytaikhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnquanlytaikhoan.ForeColor = System.Drawing.Color.White;
            this.btnquanlytaikhoan.Location = new System.Drawing.Point(22, 117);
            this.btnquanlytaikhoan.Name = "btnquanlytaikhoan";
            this.btnquanlytaikhoan.Size = new System.Drawing.Size(209, 60);
            this.btnquanlytaikhoan.TabIndex = 0;
            this.btnquanlytaikhoan.Text = "Quản lý tài khoản";
            this.btnquanlytaikhoan.UseVisualStyleBackColor = false;
            this.btnquanlytaikhoan.Click += new System.EventHandler(this.btnquanlytaikhoan_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(346, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(784, 248);
            this.dataGridView1.TabIndex = 1;
            // 
            // AdminHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 627);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.SideBarAdmin);
            this.Name = "AdminHome";
            this.Text = "AdminHome";
            this.SideBarAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SideBarAdmin;
        private System.Windows.Forms.Button btnquanlytaikhoan;
        private System.Windows.Forms.Button btnthongtincanhan;
        private System.Windows.Forms.Button btnxembaocao;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}