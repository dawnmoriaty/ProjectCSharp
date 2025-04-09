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
            this.btnqldanhmucsanpham = new System.Windows.Forms.Button();
            this.btnxembaocao = new System.Windows.Forms.Button();
            this.btnquanlytaikhoan = new System.Windows.Forms.Button();
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.setStatus = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.groupBoxquanly = new System.Windows.Forms.GroupBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SideBarAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            this.groupBoxquanly.SuspendLayout();
            this.SuspendLayout();
            // 
            // SideBarAdmin
            // 
            this.SideBarAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.SideBarAdmin.Controls.Add(this.btnqldanhmucsanpham);
            this.SideBarAdmin.Controls.Add(this.btnxembaocao);
            this.SideBarAdmin.Controls.Add(this.btnquanlytaikhoan);
            this.SideBarAdmin.Location = new System.Drawing.Point(0, 1);
            this.SideBarAdmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SideBarAdmin.Name = "SideBarAdmin";
            this.SideBarAdmin.Size = new System.Drawing.Size(303, 782);
            this.SideBarAdmin.TabIndex = 0;
            // 
            // btnqldanhmucsanpham
            // 
            this.btnqldanhmucsanpham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnqldanhmucsanpham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnqldanhmucsanpham.ForeColor = System.Drawing.Color.White;
            this.btnqldanhmucsanpham.Location = new System.Drawing.Point(24, 501);
            this.btnqldanhmucsanpham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnqldanhmucsanpham.Name = "btnqldanhmucsanpham";
            this.btnqldanhmucsanpham.Size = new System.Drawing.Size(235, 75);
            this.btnqldanhmucsanpham.TabIndex = 2;
            this.btnqldanhmucsanpham.Text = "Quản lý danh mục giao dịch";
            this.btnqldanhmucsanpham.UseVisualStyleBackColor = false;
            this.btnqldanhmucsanpham.Click += new System.EventHandler(this.btnthongtincanhan_Click);
            // 
            // btnxembaocao
            // 
            this.btnxembaocao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnxembaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxembaocao.ForeColor = System.Drawing.Color.White;
            this.btnxembaocao.Location = new System.Drawing.Point(24, 297);
            this.btnxembaocao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnxembaocao.Name = "btnxembaocao";
            this.btnxembaocao.Size = new System.Drawing.Size(235, 75);
            this.btnxembaocao.TabIndex = 1;
            this.btnxembaocao.Text = "Xem báo cáo";
            this.btnxembaocao.UseVisualStyleBackColor = false;
            this.btnxembaocao.Click += new System.EventHandler(this.btnxembaocao_Click);
            // 
            // btnquanlytaikhoan
            // 
            this.btnquanlytaikhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnquanlytaikhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnquanlytaikhoan.ForeColor = System.Drawing.Color.White;
            this.btnquanlytaikhoan.Location = new System.Drawing.Point(24, 94);
            this.btnquanlytaikhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnquanlytaikhoan.Name = "btnquanlytaikhoan";
            this.btnquanlytaikhoan.Size = new System.Drawing.Size(235, 75);
            this.btnquanlytaikhoan.TabIndex = 0;
            this.btnquanlytaikhoan.Text = "Quản lý tài khoản";
            this.btnquanlytaikhoan.UseVisualStyleBackColor = false;
            this.btnquanlytaikhoan.Click += new System.EventHandler(this.btnquanlytaikhoan_Click);
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUser.Location = new System.Drawing.Point(819, 47);
            this.dataGridViewUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.ReadOnly = true;
            this.dataGridViewUser.RowHeadersWidth = 51;
            this.dataGridViewUser.RowTemplate.Height = 24;
            this.dataGridViewUser.Size = new System.Drawing.Size(433, 520);
            this.dataGridViewUser.TabIndex = 1;
            this.dataGridViewUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUser_CellClick);
            // 
            // setStatus
            // 
            this.setStatus.Location = new System.Drawing.Point(46, 243);
            this.setStatus.Name = "setStatus";
            this.setStatus.Size = new System.Drawing.Size(267, 51);
            this.setStatus.TabIndex = 2;
            this.setStatus.Text = "Vo hieu hoa tai khoan";
            this.setStatus.UseVisualStyleBackColor = true;
            this.setStatus.Click += new System.EventHandler(this.setStatus_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(167, 130);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(209, 26);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(42, 136);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(119, 20);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Ten nguoi dung";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(77, 190);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(84, 20);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Trang Thai";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(167, 187);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(62, 26);
            this.txtStatus.TabIndex = 7;
            // 
            // groupBoxquanly
            // 
            this.groupBoxquanly.Controls.Add(this.txtUserId);
            this.groupBoxquanly.Controls.Add(this.label1);
            this.groupBoxquanly.Controls.Add(this.lblName);
            this.groupBoxquanly.Controls.Add(this.lblStatus);
            this.groupBoxquanly.Controls.Add(this.setStatus);
            this.groupBoxquanly.Controls.Add(this.txtStatus);
            this.groupBoxquanly.Controls.Add(this.txtName);
            this.groupBoxquanly.Location = new System.Drawing.Point(349, 36);
            this.groupBoxquanly.Name = "groupBoxquanly";
            this.groupBoxquanly.Size = new System.Drawing.Size(401, 531);
            this.groupBoxquanly.TabIndex = 8;
            this.groupBoxquanly.TabStop = false;
            this.groupBoxquanly.Text = "Quan ly tai khoan nguoi dung";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(167, 83);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.Size = new System.Drawing.Size(62, 26);
            this.txtUserId.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "ID";
            // 
            // AdminHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 782);
            this.Controls.Add(this.dataGridViewUser);
            this.Controls.Add(this.SideBarAdmin);
            this.Controls.Add(this.groupBoxquanly);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AdminHome";
            this.Text = "AdminHome";
            this.SideBarAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            this.groupBoxquanly.ResumeLayout(false);
            this.groupBoxquanly.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SideBarAdmin;
        private System.Windows.Forms.Button btnquanlytaikhoan;
        private System.Windows.Forms.Button btnqldanhmucsanpham;
        private System.Windows.Forms.Button btnxembaocao;
        private System.Windows.Forms.DataGridView dataGridViewUser;
        private System.Windows.Forms.Button setStatus;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.GroupBox groupBoxquanly;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label1;
    }
}