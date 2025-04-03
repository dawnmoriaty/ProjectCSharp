namespace ProjectCSharp
{
    partial class thongtincanhan
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTennguoidung = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnthaydoimatkhau = new System.Windows.Forms.Button();
            this.btnthaydoithongtincanhan = new System.Windows.Forms.Button();
            this.btnxoataikhoan = new System.Windows.Forms.Button();
            this.btndangxuat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin cá nhân";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên người dùng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(89, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // txtTennguoidung
            // 
            this.txtTennguoidung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTennguoidung.Location = new System.Drawing.Point(348, 132);
            this.txtTennguoidung.Name = "txtTennguoidung";
            this.txtTennguoidung.ReadOnly = true;
            this.txtTennguoidung.Size = new System.Drawing.Size(359, 30);
            this.txtTennguoidung.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(348, 190);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(359, 30);
            this.txtEmail.TabIndex = 4;
            // 
            // btnthaydoimatkhau
            // 
            this.btnthaydoimatkhau.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnthaydoimatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthaydoimatkhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnthaydoimatkhau.Location = new System.Drawing.Point(254, 255);
            this.btnthaydoimatkhau.Name = "btnthaydoimatkhau";
            this.btnthaydoimatkhau.Size = new System.Drawing.Size(355, 58);
            this.btnthaydoimatkhau.TabIndex = 5;
            this.btnthaydoimatkhau.Text = "Thay đổi mật khẩu";
            this.btnthaydoimatkhau.UseVisualStyleBackColor = false;
            this.btnthaydoimatkhau.Click += new System.EventHandler(this.btnthaydoimatkhau_Click);
            // 
            // btnthaydoithongtincanhan
            // 
            this.btnthaydoithongtincanhan.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnthaydoithongtincanhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthaydoithongtincanhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnthaydoithongtincanhan.Location = new System.Drawing.Point(254, 336);
            this.btnthaydoithongtincanhan.Name = "btnthaydoithongtincanhan";
            this.btnthaydoithongtincanhan.Size = new System.Drawing.Size(355, 58);
            this.btnthaydoithongtincanhan.TabIndex = 6;
            this.btnthaydoithongtincanhan.Text = "Thay đổi thông tin cá nhân";
            this.btnthaydoithongtincanhan.UseVisualStyleBackColor = false;
            this.btnthaydoithongtincanhan.Click += new System.EventHandler(this.btnthaydoithongtincanhan_Click);
            // 
            // btnxoataikhoan
            // 
            this.btnxoataikhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnxoataikhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoataikhoan.ForeColor = System.Drawing.Color.White;
            this.btnxoataikhoan.Location = new System.Drawing.Point(254, 411);
            this.btnxoataikhoan.Name = "btnxoataikhoan";
            this.btnxoataikhoan.Size = new System.Drawing.Size(355, 58);
            this.btnxoataikhoan.TabIndex = 7;
            this.btnxoataikhoan.Text = "Xoá tài khoản";
            this.btnxoataikhoan.UseVisualStyleBackColor = false;
            this.btnxoataikhoan.Click += new System.EventHandler(this.btnxoataikhoan_Click);
            // 
            // btndangxuat
            // 
            this.btndangxuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btndangxuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndangxuat.ForeColor = System.Drawing.Color.White;
            this.btndangxuat.Location = new System.Drawing.Point(644, 411);
            this.btndangxuat.Name = "btndangxuat";
            this.btndangxuat.Size = new System.Drawing.Size(193, 58);
            this.btndangxuat.TabIndex = 8;
            this.btndangxuat.Text = "Đăng xuất";
            this.btndangxuat.UseVisualStyleBackColor = false;
            this.btndangxuat.Click += new System.EventHandler(this.btndangxuat_Click);
            // 
            // thongtincanhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btndangxuat);
            this.Controls.Add(this.btnxoataikhoan);
            this.Controls.Add(this.btnthaydoithongtincanhan);
            this.Controls.Add(this.btnthaydoimatkhau);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTennguoidung);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "thongtincanhan";
            this.Size = new System.Drawing.Size(855, 496);
            this.Load += new System.EventHandler(this.thongtincanhan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTennguoidung;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnthaydoimatkhau;
        private System.Windows.Forms.Button btnthaydoithongtincanhan;
        private System.Windows.Forms.Button btnxoataikhoan;
        private System.Windows.Forms.Button btndangxuat;
    }
}
