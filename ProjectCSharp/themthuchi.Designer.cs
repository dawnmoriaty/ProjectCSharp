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
            this.description = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXacnhan = new System.Windows.Forms.Button();
            this.listdanhmuc = new System.Windows.Forms.ListBox();
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
            this.label1.Location = new System.Drawing.Point(271, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý thu chi cá nhân";
            // 
            // btnHienthithu
            // 
            this.btnHienthithu.BackColor = System.Drawing.Color.PaleGreen;
            this.btnHienthithu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienthithu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHienthithu.Location = new System.Drawing.Point(52, 41);
            this.btnHienthithu.Margin = new System.Windows.Forms.Padding(2);
            this.btnHienthithu.Name = "btnHienthithu";
            this.btnHienthithu.Size = new System.Drawing.Size(116, 32);
            this.btnHienthithu.TabIndex = 2;
            this.btnHienthithu.Text = "Nhận tiền";
            this.btnHienthithu.UseVisualStyleBackColor = false;
            this.btnHienthithu.Click += new System.EventHandler(this.btnHienthithu_Click);
            // 
            // btnhienthichitien
            // 
            this.btnhienthichitien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnhienthichitien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhienthichitien.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnhienthichitien.Location = new System.Drawing.Point(594, 41);
            this.btnhienthichitien.Margin = new System.Windows.Forms.Padding(2);
            this.btnhienthichitien.Name = "btnhienthichitien";
            this.btnhienthichitien.Size = new System.Drawing.Size(116, 32);
            this.btnhienthichitien.TabIndex = 3;
            this.btnhienthichitien.Text = "Chi tiền";
            this.btnhienthichitien.UseVisualStyleBackColor = false;
            this.btnhienthichitien.Click += new System.EventHandler(this.btnhienthichitien_Click);
            // 
            // DGVthuchi
            // 
            this.DGVthuchi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVthuchi.Location = new System.Drawing.Point(36, 253);
            this.DGVthuchi.Margin = new System.Windows.Forms.Padding(2);
            this.DGVthuchi.Name = "DGVthuchi";
            this.DGVthuchi.RowHeadersWidth = 51;
            this.DGVthuchi.RowTemplate.Height = 24;
            this.DGVthuchi.Size = new System.Drawing.Size(695, 272);
            this.DGVthuchi.TabIndex = 4;
            // 
            // btnLoaddulieu
            // 
            this.btnLoaddulieu.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnLoaddulieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoaddulieu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLoaddulieu.Location = new System.Drawing.Point(190, 530);
            this.btnLoaddulieu.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoaddulieu.Name = "btnLoaddulieu";
            this.btnLoaddulieu.Size = new System.Drawing.Size(400, 30);
            this.btnLoaddulieu.TabIndex = 5;
            this.btnLoaddulieu.Text = "Lấy dữ liệu";
            this.btnLoaddulieu.UseVisualStyleBackColor = false;
            // 
            // Thuchi
            // 
            this.Thuchi.Controls.Add(this.description);
            this.Thuchi.Controls.Add(this.label4);
            this.Thuchi.Controls.Add(this.btnXacnhan);
            this.Thuchi.Controls.Add(this.listdanhmuc);
            this.Thuchi.Controls.Add(this.label2);
            this.Thuchi.Controls.Add(this.amount);
            this.Thuchi.Controls.Add(this.label3);
            this.Thuchi.Location = new System.Drawing.Point(36, 86);
            this.Thuchi.Margin = new System.Windows.Forms.Padding(2);
            this.Thuchi.Name = "Thuchi";
            this.Thuchi.Padding = new System.Windows.Forms.Padding(2);
            this.Thuchi.Size = new System.Drawing.Size(695, 154);
            this.Thuchi.TabIndex = 6;
            this.Thuchi.TabStop = false;
            this.Thuchi.Text = "Thêm thi chi";
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(494, 67);
            this.description.Margin = new System.Windows.Forms.Padding(2);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(127, 26);
            this.description.TabIndex = 11;
            this.description.TextChanged += new System.EventHandler(this.description_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(436, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mô tả";
            // 
            // btnXacnhan
            // 
            this.btnXacnhan.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXacnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacnhan.ForeColor = System.Drawing.Color.Transparent;
            this.btnXacnhan.Location = new System.Drawing.Point(494, 117);
            this.btnXacnhan.Margin = new System.Windows.Forms.Padding(2);
            this.btnXacnhan.Name = "btnXacnhan";
            this.btnXacnhan.Size = new System.Drawing.Size(123, 29);
            this.btnXacnhan.TabIndex = 9;
            this.btnXacnhan.Text = "Xác nhận";
            this.btnXacnhan.UseVisualStyleBackColor = false;
            this.btnXacnhan.Click += new System.EventHandler(this.btnXacnhan_Click);
            // 
            // listdanhmuc
            // 
            this.listdanhmuc.FormattingEnabled = true;
            this.listdanhmuc.Location = new System.Drawing.Point(242, 15);
            this.listdanhmuc.Margin = new System.Windows.Forms.Padding(2);
            this.listdanhmuc.Name = "listdanhmuc";
            this.listdanhmuc.Size = new System.Drawing.Size(377, 30);
            this.listdanhmuc.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Chọn danh mục:";
            // 
            // amount
            // 
            this.amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amount.Location = new System.Drawing.Point(242, 67);
            this.amount.Margin = new System.Windows.Forms.Padding(2);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(106, 26);
            this.amount.TabIndex = 6;
            this.amount.TextChanged += new System.EventHandler(this.amount_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(68, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nhập vào số tiền:";
            // 
            // themthuchi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Thuchi);
            this.Controls.Add(this.btnLoaddulieu);
            this.Controls.Add(this.DGVthuchi);
            this.Controls.Add(this.btnhienthichitien);
            this.Controls.Add(this.btnHienthithu);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "themthuchi";
            this.Size = new System.Drawing.Size(770, 581);
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
        private System.Windows.Forms.ListBox listdanhmuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label label4;
    }
}
