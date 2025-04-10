namespace ProjectCSharp.Component.User
{
    partial class Sidebar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sidebar));
            this.btnquanlydanhmuc = new System.Windows.Forms.Button();
            this.taogiaodich = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.PictureBox();
            this.btnthongtin = new System.Windows.Forms.Button();
            this.btnbaocao = new System.Windows.Forms.Button();
            this.btnsogiaodich = new System.Windows.Forms.Button();
            this.btnHomeUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlus)).BeginInit();
            this.SuspendLayout();
            // 
            // btnquanlydanhmuc
            // 
            this.btnquanlydanhmuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnquanlydanhmuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnquanlydanhmuc.ForeColor = System.Drawing.Color.White;
            this.btnquanlydanhmuc.Image = global::ProjectCSharp.Properties.Resources.menu;
            this.btnquanlydanhmuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnquanlydanhmuc.Location = new System.Drawing.Point(12, 236);
            this.btnquanlydanhmuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnquanlydanhmuc.Name = "btnquanlydanhmuc";
            this.btnquanlydanhmuc.Size = new System.Drawing.Size(207, 57);
            this.btnquanlydanhmuc.TabIndex = 6;
            this.btnquanlydanhmuc.Text = " Danh mục";
            this.btnquanlydanhmuc.UseVisualStyleBackColor = false;
            this.btnquanlydanhmuc.Click += new System.EventHandler(this.btnquanlydanhmuc_Click);
            // 
            // taogiaodich
            // 
            this.taogiaodich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.taogiaodich.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taogiaodich.ForeColor = System.Drawing.Color.White;
            this.taogiaodich.Image = global::ProjectCSharp.Properties.Resources.btnPlus;
            this.taogiaodich.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taogiaodich.Location = new System.Drawing.Point(12, 304);
            this.taogiaodich.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.taogiaodich.Name = "taogiaodich";
            this.taogiaodich.Size = new System.Drawing.Size(207, 57);
            this.taogiaodich.TabIndex = 5;
            this.taogiaodich.Text = "     Tạo giao dịch";
            this.taogiaodich.UseVisualStyleBackColor = false;
            this.taogiaodich.Click += new System.EventHandler(this.taogiaodich_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Image = ((System.Drawing.Image)(resources.GetObject("btnPlus.Image")));
            this.btnPlus.Location = new System.Drawing.Point(44, 13);
            this.btnPlus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(128, 128);
            this.btnPlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPlus.TabIndex = 4;
            this.btnPlus.TabStop = false;
            // 
            // btnthongtin
            // 
            this.btnthongtin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnthongtin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthongtin.ForeColor = System.Drawing.Color.White;
            this.btnthongtin.Image = global::ProjectCSharp.Properties.Resources.btn_User;
            this.btnthongtin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthongtin.Location = new System.Drawing.Point(12, 508);
            this.btnthongtin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnthongtin.Name = "btnthongtin";
            this.btnthongtin.Size = new System.Drawing.Size(207, 57);
            this.btnthongtin.TabIndex = 3;
            this.btnthongtin.Text = "Tài Khoản";
            this.btnthongtin.UseVisualStyleBackColor = false;
            this.btnthongtin.Click += new System.EventHandler(this.btnthongtin_Click);
            // 
            // btnbaocao
            // 
            this.btnbaocao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnbaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbaocao.ForeColor = System.Drawing.Color.White;
            this.btnbaocao.Image = global::ProjectCSharp.Properties.Resources.report;
            this.btnbaocao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbaocao.Location = new System.Drawing.Point(12, 376);
            this.btnbaocao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnbaocao.Name = "btnbaocao";
            this.btnbaocao.Size = new System.Drawing.Size(207, 57);
            this.btnbaocao.TabIndex = 2;
            this.btnbaocao.Text = "Báo cáo";
            this.btnbaocao.UseVisualStyleBackColor = false;
            this.btnbaocao.Click += new System.EventHandler(this.btnthuchi_Click);
            // 
            // btnsogiaodich
            // 
            this.btnsogiaodich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnsogiaodich.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsogiaodich.ForeColor = System.Drawing.Color.White;
            this.btnsogiaodich.Image = global::ProjectCSharp.Properties.Resources.wallet_filled_money_tool;
            this.btnsogiaodich.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsogiaodich.Location = new System.Drawing.Point(12, 443);
            this.btnsogiaodich.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsogiaodich.Name = "btnsogiaodich";
            this.btnsogiaodich.Size = new System.Drawing.Size(207, 57);
            this.btnsogiaodich.TabIndex = 1;
            this.btnsogiaodich.Text = "    Sổ giao dịch";
            this.btnsogiaodich.UseVisualStyleBackColor = false;
            this.btnsogiaodich.Click += new System.EventHandler(this.btnsogiaodich_Click);
            // 
            // btnHomeUser
            // 
            this.btnHomeUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnHomeUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeUser.ForeColor = System.Drawing.Color.White;
            this.btnHomeUser.Image = global::ProjectCSharp.Properties.Resources.home;
            this.btnHomeUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHomeUser.Location = new System.Drawing.Point(12, 173);
            this.btnHomeUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHomeUser.Name = "btnHomeUser";
            this.btnHomeUser.Size = new System.Drawing.Size(207, 57);
            this.btnHomeUser.TabIndex = 0;
            this.btnHomeUser.Text = "      Tổng quan";
            this.btnHomeUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHomeUser.UseVisualStyleBackColor = false;
            this.btnHomeUser.Click += new System.EventHandler(this.btnHomeUser_Click);
            // 
            // Sidebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.Controls.Add(this.btnquanlydanhmuc);
            this.Controls.Add(this.taogiaodich);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnthongtin);
            this.Controls.Add(this.btnbaocao);
            this.Controls.Add(this.btnsogiaodich);
            this.Controls.Add(this.btnHomeUser);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Sidebar";
            this.Size = new System.Drawing.Size(231, 625);
            ((System.ComponentModel.ISupportInitialize)(this.btnPlus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHomeUser;
        private System.Windows.Forms.Button btnsogiaodich;
        private System.Windows.Forms.Button btnbaocao;
        private System.Windows.Forms.Button btnthongtin;
        private System.Windows.Forms.PictureBox btnPlus;
        private System.Windows.Forms.Button taogiaodich;
        private System.Windows.Forms.Button btnquanlydanhmuc;
    }
}
