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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminHome));
            this.SideBarAdmin = new System.Windows.Forms.Panel();
            this.btnquanlytaikhoan = new System.Windows.Forms.Button();
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.setStatus = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBoxquanly = new System.Windows.Forms.GroupBox();
            this.rdInActive = new System.Windows.Forms.RadioButton();
            this.rdActive = new System.Windows.Forms.RadioButton();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btndangxuat = new System.Windows.Forms.Button();
            this.SideBarAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            this.groupBoxquanly.SuspendLayout();
            this.SuspendLayout();
            // 
            // SideBarAdmin
            // 
            this.SideBarAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.SideBarAdmin.Controls.Add(this.btndangxuat);
            this.SideBarAdmin.Controls.Add(this.btnquanlytaikhoan);
            this.SideBarAdmin.Location = new System.Drawing.Point(0, 1);
            this.SideBarAdmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SideBarAdmin.Name = "SideBarAdmin";
            this.SideBarAdmin.Size = new System.Drawing.Size(232, 626);
            this.SideBarAdmin.TabIndex = 0;
            // 
            // btnquanlytaikhoan
            // 
            this.btnquanlytaikhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnquanlytaikhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnquanlytaikhoan.ForeColor = System.Drawing.Color.White;
            this.btnquanlytaikhoan.Location = new System.Drawing.Point(12, 20);
            this.btnquanlytaikhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnquanlytaikhoan.Name = "btnquanlytaikhoan";
            this.btnquanlytaikhoan.Size = new System.Drawing.Size(209, 60);
            this.btnquanlytaikhoan.TabIndex = 0;
            this.btnquanlytaikhoan.Text = "Quản lý tài khoản";
            this.btnquanlytaikhoan.UseVisualStyleBackColor = false;
            this.btnquanlytaikhoan.Click += new System.EventHandler(this.btnquanlytaikhoan_Click);
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUser.Location = new System.Drawing.Point(279, 290);
            this.dataGridViewUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.ReadOnly = true;
            this.dataGridViewUser.RowHeadersWidth = 51;
            this.dataGridViewUser.RowTemplate.Height = 24;
            this.dataGridViewUser.Size = new System.Drawing.Size(913, 314);
            this.dataGridViewUser.TabIndex = 1;
            this.dataGridViewUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUser_CellClick);
            // 
            // setStatus
            // 
            this.setStatus.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.setStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.setStatus.Location = new System.Drawing.Point(94, 189);
            this.setStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.setStatus.Name = "setStatus";
            this.setStatus.Size = new System.Drawing.Size(272, 41);
            this.setStatus.TabIndex = 2;
            this.setStatus.Text = "Cập nhật trạng thái tài khoản";
            this.setStatus.UseVisualStyleBackColor = false;
            this.setStatus.Click += new System.EventHandler(this.setStatus_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(160, 103);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(216, 24);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(37, 109);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(109, 18);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Tên người dùng";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(37, 150);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(73, 18);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Trạng thái";
            // 
            // groupBoxquanly
            // 
            this.groupBoxquanly.Controls.Add(this.rdInActive);
            this.groupBoxquanly.Controls.Add(this.rdActive);
            this.groupBoxquanly.Controls.Add(this.txtUserId);
            this.groupBoxquanly.Controls.Add(this.label1);
            this.groupBoxquanly.Controls.Add(this.lblName);
            this.groupBoxquanly.Controls.Add(this.lblStatus);
            this.groupBoxquanly.Controls.Add(this.setStatus);
            this.groupBoxquanly.Controls.Add(this.txtName);
            this.groupBoxquanly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxquanly.Location = new System.Drawing.Point(493, 21);
            this.groupBoxquanly.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxquanly.Name = "groupBoxquanly";
            this.groupBoxquanly.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxquanly.Size = new System.Drawing.Size(525, 265);
            this.groupBoxquanly.TabIndex = 8;
            this.groupBoxquanly.TabStop = false;
            this.groupBoxquanly.Text = "Quản lý tài khoản người dùng";
            // 
            // rdInActive
            // 
            this.rdInActive.AutoSize = true;
            this.rdInActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdInActive.Location = new System.Drawing.Point(293, 146);
            this.rdInActive.Name = "rdInActive";
            this.rdInActive.Size = new System.Drawing.Size(107, 22);
            this.rdInActive.TabIndex = 11;
            this.rdInActive.TabStop = true;
            this.rdInActive.Text = "Vô hiệu hoá";
            this.rdInActive.UseVisualStyleBackColor = true;
            // 
            // rdActive
            // 
            this.rdActive.AutoSize = true;
            this.rdActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdActive.Location = new System.Drawing.Point(159, 146);
            this.rdActive.Name = "rdActive";
            this.rdActive.Size = new System.Drawing.Size(91, 22);
            this.rdActive.TabIndex = 10;
            this.rdActive.TabStop = true;
            this.rdActive.Text = "Sẵn sàng";
            this.rdActive.UseVisualStyleBackColor = true;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(159, 69);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.Size = new System.Drawing.Size(93, 24);
            this.txtUserId.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "ID";
            // 
            // btndangxuat
            // 
            this.btndangxuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btndangxuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndangxuat.ForeColor = System.Drawing.Color.White;
            this.btndangxuat.Image = global::ProjectCSharp.Properties.Resources.logout;
            this.btndangxuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndangxuat.Location = new System.Drawing.Point(12, 543);
            this.btndangxuat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btndangxuat.Name = "btndangxuat";
            this.btndangxuat.Size = new System.Drawing.Size(209, 60);
            this.btndangxuat.TabIndex = 1;
            this.btndangxuat.Text = "Đăng xuất";
            this.btndangxuat.UseVisualStyleBackColor = false;
            this.btndangxuat.Click += new System.EventHandler(this.btndangxuat_Click);
            // 
            // AdminHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 626);
            this.Controls.Add(this.dataGridViewUser);
            this.Controls.Add(this.SideBarAdmin);
            this.Controls.Add(this.groupBoxquanly);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.DataGridView dataGridViewUser;
        private System.Windows.Forms.Button setStatus;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBoxquanly;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdInActive;
        private System.Windows.Forms.RadioButton rdActive;
        private System.Windows.Forms.Button btndangxuat;
    }
}