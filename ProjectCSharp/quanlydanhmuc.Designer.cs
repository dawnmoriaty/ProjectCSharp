namespace ProjectCSharp
{
    partial class quanlydanhmuc
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
            this.groupBoxthem = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rdChi = new System.Windows.Forms.RadioButton();
            this.rdThu = new System.Windows.Forms.RadioButton();
            this.txtMota = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTendanhmuc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewquanlydanhmuc = new System.Windows.Forms.DataGridView();
            this.bntLoadDulieu = new System.Windows.Forms.Button();
            this.groupBoxthem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewquanlydanhmuc)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxthem
            // 
            this.groupBoxthem.Controls.Add(this.btnClear);
            this.groupBoxthem.Controls.Add(this.btnXoa);
            this.groupBoxthem.Controls.Add(this.btnSua);
            this.groupBoxthem.Controls.Add(this.btnThem);
            this.groupBoxthem.Controls.Add(this.label3);
            this.groupBoxthem.Controls.Add(this.rdChi);
            this.groupBoxthem.Controls.Add(this.rdThu);
            this.groupBoxthem.Controls.Add(this.txtMota);
            this.groupBoxthem.Controls.Add(this.label2);
            this.groupBoxthem.Controls.Add(this.txtTendanhmuc);
            this.groupBoxthem.Controls.Add(this.label1);
            this.groupBoxthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxthem.Location = new System.Drawing.Point(22, 138);
            this.groupBoxthem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxthem.Name = "groupBoxthem";
            this.groupBoxthem.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxthem.Size = new System.Drawing.Size(453, 591);
            this.groupBoxthem.TabIndex = 0;
            this.groupBoxthem.TabStop = false;
            this.groupBoxthem.Text = "Danh mục";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Violet;
            this.btnClear.Location = new System.Drawing.Point(262, 489);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(148, 62);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Xoá thông tin";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnXoa.Location = new System.Drawing.Point(56, 489);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(129, 62);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xoá danh mục";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSua.Location = new System.Drawing.Point(260, 380);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(151, 62);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Cập nhật danh mục";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThem.Location = new System.Drawing.Point(56, 380);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(129, 62);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm danh mục";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Loại hình";
            // 
            // rdChi
            // 
            this.rdChi.AutoSize = true;
            this.rdChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdChi.Location = new System.Drawing.Point(295, 310);
            this.rdChi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdChi.Name = "rdChi";
            this.rdChi.Size = new System.Drawing.Size(124, 26);
            this.rdChi.TabIndex = 5;
            this.rdChi.TabStop = true;
            this.rdChi.Text = "Khoản chi";
            this.rdChi.UseVisualStyleBackColor = true;
            // 
            // rdThu
            // 
            this.rdThu.AutoSize = true;
            this.rdThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdThu.Location = new System.Drawing.Point(163, 310);
            this.rdThu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdThu.Name = "rdThu";
            this.rdThu.Size = new System.Drawing.Size(126, 26);
            this.rdThu.TabIndex = 4;
            this.rdThu.TabStop = true;
            this.rdThu.Text = "Khoản thu";
            this.rdThu.UseVisualStyleBackColor = true;
            // 
            // txtMota
            // 
            this.txtMota.Location = new System.Drawing.Point(204, 154);
            this.txtMota.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMota.Multiline = true;
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(206, 108);
            this.txtMota.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mô tả chi tiết";
            // 
            // txtTendanhmuc
            // 
            this.txtTendanhmuc.Location = new System.Drawing.Point(205, 88);
            this.txtTendanhmuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTendanhmuc.Name = "txtTendanhmuc";
            this.txtTendanhmuc.Size = new System.Drawing.Size(206, 26);
            this.txtTendanhmuc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên danh mục";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(476, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 38);
            this.label4.TabIndex = 2;
            this.label4.Text = "Quản lý danh mục";
            // 
            // dataGridViewquanlydanhmuc
            // 
            this.dataGridViewquanlydanhmuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewquanlydanhmuc.Location = new System.Drawing.Point(535, 148);
            this.dataGridViewquanlydanhmuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewquanlydanhmuc.Name = "dataGridViewquanlydanhmuc";
            this.dataGridViewquanlydanhmuc.RowHeadersWidth = 51;
            this.dataGridViewquanlydanhmuc.RowTemplate.Height = 24;
            this.dataGridViewquanlydanhmuc.Size = new System.Drawing.Size(675, 510);
            this.dataGridViewquanlydanhmuc.TabIndex = 3;
            this.dataGridViewquanlydanhmuc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewquanlydanhmuc_CellClick);
            // 
            // bntLoadDulieu
            // 
            this.bntLoadDulieu.BackColor = System.Drawing.Color.PaleGreen;
            this.bntLoadDulieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntLoadDulieu.Location = new System.Drawing.Point(653, 690);
            this.bntLoadDulieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bntLoadDulieu.Name = "bntLoadDulieu";
            this.bntLoadDulieu.Size = new System.Drawing.Size(486, 39);
            this.bntLoadDulieu.TabIndex = 4;
            this.bntLoadDulieu.Text = "Tải dữ liệu danh mục";
            this.bntLoadDulieu.UseVisualStyleBackColor = false;
            this.bntLoadDulieu.Click += new System.EventHandler(this.bntLoadDulieu_Click);
            // 
            // quanlydanhmuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bntLoadDulieu);
            this.Controls.Add(this.dataGridViewquanlydanhmuc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBoxthem);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "quanlydanhmuc";
            this.Size = new System.Drawing.Size(1281, 891);
            this.Load += new System.EventHandler(this.quanlydanhmuc_Load);
            this.groupBoxthem.ResumeLayout(false);
            this.groupBoxthem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewquanlydanhmuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxthem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTendanhmuc;
        private System.Windows.Forms.RadioButton rdChi;
        private System.Windows.Forms.RadioButton rdThu;
        private System.Windows.Forms.TextBox txtMota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView DGVdanhmuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewquanlydanhmuc;
        private System.Windows.Forms.Button bntLoadDulieu;
    }
}
