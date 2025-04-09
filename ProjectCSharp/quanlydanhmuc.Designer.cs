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
            this.groupBoxthem.Location = new System.Drawing.Point(20, 110);
            this.groupBoxthem.Name = "groupBoxthem";
            this.groupBoxthem.Size = new System.Drawing.Size(403, 473);
            this.groupBoxthem.TabIndex = 0;
            this.groupBoxthem.TabStop = false;
            this.groupBoxthem.Text = "Danh mục";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(233, 391);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 50);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Xoá thông tin";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(50, 391);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(115, 50);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xoá danh mục";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(231, 304);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(134, 50);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Cập nhật danh mục";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(50, 304);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(115, 50);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm danh mục";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Loại hình";
            // 
            // rdChi
            // 
            this.rdChi.AutoSize = true;
            this.rdChi.Location = new System.Drawing.Point(262, 248);
            this.rdChi.Name = "rdChi";
            this.rdChi.Size = new System.Drawing.Size(86, 20);
            this.rdChi.TabIndex = 5;
            this.rdChi.TabStop = true;
            this.rdChi.Text = "Khoản chi";
            this.rdChi.UseVisualStyleBackColor = true;
            // 
            // rdThu
            // 
            this.rdThu.AutoSize = true;
            this.rdThu.Location = new System.Drawing.Point(145, 248);
            this.rdThu.Name = "rdThu";
            this.rdThu.Size = new System.Drawing.Size(86, 20);
            this.rdThu.TabIndex = 4;
            this.rdThu.TabStop = true;
            this.rdThu.Text = "Khoản thu";
            this.rdThu.UseVisualStyleBackColor = true;
            // 
            // txtMota
            // 
            this.txtMota.Location = new System.Drawing.Point(181, 123);
            this.txtMota.Multiline = true;
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(184, 87);
            this.txtMota.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mô tả chi tiết";
            // 
            // txtTendanhmuc
            // 
            this.txtTendanhmuc.Location = new System.Drawing.Point(181, 66);
            this.txtTendanhmuc.Name = "txtTendanhmuc";
            this.txtTendanhmuc.Size = new System.Drawing.Size(184, 22);
            this.txtTendanhmuc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên danh mục";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(339, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 32);
            this.label4.TabIndex = 2;
            this.label4.Text = "Quản lý danh mục";
            // 
            // dataGridViewquanlydanhmuc
            // 
            this.dataGridViewquanlydanhmuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewquanlydanhmuc.Location = new System.Drawing.Point(429, 117);
            this.dataGridViewquanlydanhmuc.Name = "dataGridViewquanlydanhmuc";
            this.dataGridViewquanlydanhmuc.RowHeadersWidth = 51;
            this.dataGridViewquanlydanhmuc.RowTemplate.Height = 24;
            this.dataGridViewquanlydanhmuc.Size = new System.Drawing.Size(600, 416);
            this.dataGridViewquanlydanhmuc.TabIndex = 3;
            this.dataGridViewquanlydanhmuc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewquanlydanhmuc_CellClick);
            // 
            // bntLoadDulieu
            // 
            this.bntLoadDulieu.Location = new System.Drawing.Point(539, 552);
            this.bntLoadDulieu.Name = "bntLoadDulieu";
            this.bntLoadDulieu.Size = new System.Drawing.Size(432, 31);
            this.bntLoadDulieu.TabIndex = 4;
            this.bntLoadDulieu.Text = "Tải dữ liệu danh mục";
            this.bntLoadDulieu.UseVisualStyleBackColor = true;
            this.bntLoadDulieu.Click += new System.EventHandler(this.bntLoadDulieu_Click);
            // 
            // quanlydanhmuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bntLoadDulieu);
            this.Controls.Add(this.dataGridViewquanlydanhmuc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBoxthem);
            this.Name = "quanlydanhmuc";
            this.Size = new System.Drawing.Size(1061, 754);
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
