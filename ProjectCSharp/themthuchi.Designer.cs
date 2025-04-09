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
            this.panelThuChi = new System.Windows.Forms.Panel();
            this.btnHienthithu = new System.Windows.Forms.Button();
            this.btnhienthichitien = new System.Windows.Forms.Button();
            this.DGVthuchi = new System.Windows.Forms.DataGridView();
            this.btnLoaddulieu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVthuchi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(361, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý thu chi cá nhân";
            // 
            // panelThuChi
            // 
            this.panelThuChi.Location = new System.Drawing.Point(52, 96);
            this.panelThuChi.Name = "panelThuChi";
            this.panelThuChi.Size = new System.Drawing.Size(924, 170);
            this.panelThuChi.TabIndex = 1;
            // 
            // btnHienthithu
            // 
            this.btnHienthithu.BackColor = System.Drawing.Color.PaleGreen;
            this.btnHienthithu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienthithu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHienthithu.Location = new System.Drawing.Point(70, 50);
            this.btnHienthithu.Name = "btnHienthithu";
            this.btnHienthithu.Size = new System.Drawing.Size(154, 40);
            this.btnHienthithu.TabIndex = 2;
            this.btnHienthithu.Text = "Nhận tiền";
            this.btnHienthithu.UseVisualStyleBackColor = false;
            // 
            // btnhienthichitien
            // 
            this.btnhienthichitien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnhienthichitien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhienthichitien.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnhienthichitien.Location = new System.Drawing.Point(792, 50);
            this.btnhienthichitien.Name = "btnhienthichitien";
            this.btnhienthichitien.Size = new System.Drawing.Size(154, 40);
            this.btnhienthichitien.TabIndex = 3;
            this.btnhienthichitien.Text = "Chi tiền";
            this.btnhienthichitien.UseVisualStyleBackColor = false;
            // 
            // DGVthuchi
            // 
            this.DGVthuchi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVthuchi.Location = new System.Drawing.Point(49, 272);
            this.DGVthuchi.Name = "DGVthuchi";
            this.DGVthuchi.RowHeadersWidth = 51;
            this.DGVthuchi.RowTemplate.Height = 24;
            this.DGVthuchi.Size = new System.Drawing.Size(927, 335);
            this.DGVthuchi.TabIndex = 4;
            // 
            // btnLoaddulieu
            // 
            this.btnLoaddulieu.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnLoaddulieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoaddulieu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLoaddulieu.Location = new System.Drawing.Point(255, 613);
            this.btnLoaddulieu.Name = "btnLoaddulieu";
            this.btnLoaddulieu.Size = new System.Drawing.Size(533, 37);
            this.btnLoaddulieu.TabIndex = 5;
            this.btnLoaddulieu.Text = "Lấy dữ liệu";
            this.btnLoaddulieu.UseVisualStyleBackColor = false;
            // 
            // themthuchi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoaddulieu);
            this.Controls.Add(this.DGVthuchi);
            this.Controls.Add(this.btnhienthichitien);
            this.Controls.Add(this.btnHienthithu);
            this.Controls.Add(this.panelThuChi);
            this.Controls.Add(this.label1);
            this.Name = "themthuchi";
            this.Size = new System.Drawing.Size(1027, 687);
            ((System.ComponentModel.ISupportInitialize)(this.DGVthuchi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelThuChi;
        private System.Windows.Forms.Button btnHienthithu;
        private System.Windows.Forms.Button btnhienthichitien;
        private System.Windows.Forms.DataGridView DGVthuchi;
        private System.Windows.Forms.Button btnLoaddulieu;
    }
}
