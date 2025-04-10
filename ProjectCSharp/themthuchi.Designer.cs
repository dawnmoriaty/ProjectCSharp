namespace ProjectCSharp
{
    partial class themthuchi
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
            this.btnHienthithu = new System.Windows.Forms.Button();
            this.btnhienthichitien = new System.Windows.Forms.Button();
            this.DGVthuchi = new System.Windows.Forms.DataGridView();
            this.btnLoaddulieu = new System.Windows.Forms.Button();
            this.Thuchi = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapnhat = new System.Windows.Forms.Button();
            this.cbDanhmuc = new System.Windows.Forms.ComboBox();
            this.description = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXacnhan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVthuchi)).BeginInit();
            this.Thuchi.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(406, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý thu chi cá nhân";
            // 
            // btnHienthithu
            // 
            this.btnHienthithu.BackColor = System.Drawing.Color.PaleGreen;
            this.btnHienthithu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienthithu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHienthithu.Location = new System.Drawing.Point(78, 62);
            this.btnHienthithu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHienthithu.Name = "btnHienthithu";
            this.btnHienthithu.Size = new System.Drawing.Size(174, 49);
            this.btnHienthithu.TabIndex = 2;
            this.btnHienthithu.Text = "Khoản thu";
            this.btnHienthithu.UseVisualStyleBackColor = false;
            this.btnHienthithu.Click += new System.EventHandler(this.btnHienthithu_Click);
            // 
            // btnhienthichitien
            // 
            this.btnhienthichitien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnhienthichitien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhienthichitien.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnhienthichitien.Location = new System.Drawing.Point(891, 62);
            this.btnhienthichitien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnhienthichitien.Name = "btnhienthichitien";
            this.btnhienthichitien.Size = new System.Drawing.Size(174, 49);
            this.btnhienthichitien.TabIndex = 3;
            this.btnhienthichitien.Text = "Khoản chi";
            this.btnhienthichitien.UseVisualStyleBackColor = false;
            this.btnhienthichitien.Click += new System.EventHandler(this.btnhienthichitien_Click);
            // 
            // DGVthuchi
            // 
            this.DGVthuchi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVthuchi.Location = new System.Drawing.Point(54, 389);
            this.DGVthuchi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGVthuchi.Name = "DGVthuchi";
            this.DGVthuchi.RowHeadersWidth = 51;
            this.DGVthuchi.RowTemplate.Height = 24;
            this.DGVthuchi.Size = new System.Drawing.Size(1043, 419);
            this.DGVthuchi.TabIndex = 4;
            this.DGVthuchi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVthuchi_CellClick);
            // 
            // btnLoaddulieu
            // 
            this.btnLoaddulieu.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnLoaddulieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoaddulieu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLoaddulieu.Location = new System.Drawing.Point(285, 815);
            this.btnLoaddulieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoaddulieu.Name = "btnLoaddulieu";
            this.btnLoaddulieu.Size = new System.Drawing.Size(600, 46);
            this.btnLoaddulieu.TabIndex = 5;
            this.btnLoaddulieu.Text = "Lấy dữ liệu";
            this.btnLoaddulieu.UseVisualStyleBackColor = false;
            this.btnLoaddulieu.Click += new System.EventHandler(this.btnLoaddulieu_Click);
            // 
            // Thuchi
            // 
            this.Thuchi.Controls.Add(this.btnClear);
            this.Thuchi.Controls.Add(this.btnXoa);
            this.Thuchi.Controls.Add(this.btnCapnhat);
            this.Thuchi.Controls.Add(this.cbDanhmuc);
            this.Thuchi.Controls.Add(this.description);
            this.Thuchi.Controls.Add(this.label4);
            this.Thuchi.Controls.Add(this.btnXacnhan);
            this.Thuchi.Controls.Add(this.label2);
            this.Thuchi.Controls.Add(this.amount);
            this.Thuchi.Controls.Add(this.label3);
            this.Thuchi.Location = new System.Drawing.Point(54, 132);
            this.Thuchi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Thuchi.Name = "Thuchi";
            this.Thuchi.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Thuchi.Size = new System.Drawing.Size(1043, 238);
            this.Thuchi.TabIndex = 6;
            this.Thuchi.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Violet;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Transparent;
            this.btnClear.Image = global::ProjectCSharp.Properties.Resources.remove;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(790, 149);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(238, 69);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Xoá thông tin";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.Transparent;
            this.btnXoa.Image = global::ProjectCSharp.Properties.Resources.bin;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(543, 149);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(184, 69);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapnhat
            // 
            this.btnCapnhat.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCapnhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapnhat.ForeColor = System.Drawing.Color.Transparent;
            this.btnCapnhat.Image = global::ProjectCSharp.Properties.Resources.update;
            this.btnCapnhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapnhat.Location = new System.Drawing.Point(295, 149);
            this.btnCapnhat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCapnhat.Name = "btnCapnhat";
            this.btnCapnhat.Size = new System.Drawing.Size(184, 69);
            this.btnCapnhat.TabIndex = 13;
            this.btnCapnhat.Text = "Cập nhật";
            this.btnCapnhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapnhat.UseVisualStyleBackColor = false;
            this.btnCapnhat.Click += new System.EventHandler(this.btnCapnhat_Click);
            // 
            // cbDanhmuc
            // 
            this.cbDanhmuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDanhmuc.FormattingEnabled = true;
            this.cbDanhmuc.Location = new System.Drawing.Point(811, 29);
            this.cbDanhmuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDanhmuc.Name = "cbDanhmuc";
            this.cbDanhmuc.Size = new System.Drawing.Size(200, 37);
            this.cbDanhmuc.TabIndex = 12;
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(122, 91);
            this.description.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(447, 35);
            this.description.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mô tả:";
            // 
            // btnXacnhan
            // 
            this.btnXacnhan.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXacnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacnhan.ForeColor = System.Drawing.Color.Transparent;
            this.btnXacnhan.Image = global::ProjectCSharp.Properties.Resources.check;
            this.btnXacnhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXacnhan.Location = new System.Drawing.Point(24, 149);
            this.btnXacnhan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXacnhan.Name = "btnXacnhan";
            this.btnXacnhan.Size = new System.Drawing.Size(198, 69);
            this.btnXacnhan.TabIndex = 9;
            this.btnXacnhan.Text = "Xác nhận";
            this.btnXacnhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXacnhan.UseVisualStyleBackColor = false;
            this.btnXacnhan.Click += new System.EventHandler(this.btnXacnhan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(612, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Chọn danh mục:";
            // 
            // amount
            // 
            this.amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amount.Location = new System.Drawing.Point(243, 29);
            this.amount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(340, 35);
            this.amount.TabIndex = 6;
            this.amount.TextChanged += new System.EventHandler(this.amount_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nhập vào số tiền\r\n";
            // 
            // themthuchi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Thuchi);
            this.Controls.Add(this.btnLoaddulieu);
            this.Controls.Add(this.DGVthuchi);
            this.Controls.Add(this.btnhienthichitien);
            this.Controls.Add(this.btnHienthithu);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "themthuchi";
            this.Size = new System.Drawing.Size(1155, 894);
            ((System.ComponentModel.ISupportInitialize)(this.DGVthuchi)).EndInit();
            this.Thuchi.ResumeLayout(false);
            this.Thuchi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHienthithu;
        private System.Windows.Forms.Button btnhienthichitien;
        private System.Windows.Forms.DataGridView DGVthuchi;
        private System.Windows.Forms.Button btnLoaddulieu;
        private System.Windows.Forms.GroupBox Thuchi;
        private System.Windows.Forms.Button btnXacnhan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDanhmuc;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapnhat;
    }
}
