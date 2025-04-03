﻿namespace ProjectCSharp.Component.User
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
            this.btnHomeUser = new System.Windows.Forms.Button();
            this.btnsogiaodich = new System.Windows.Forms.Button();
            this.btnthuchi = new System.Windows.Forms.Button();
            this.btnthongtin = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlus)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHomeUser
            // 
            this.btnHomeUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnHomeUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeUser.ForeColor = System.Drawing.Color.White;
            this.btnHomeUser.Location = new System.Drawing.Point(21, 64);
            this.btnHomeUser.Name = "btnHomeUser";
            this.btnHomeUser.Size = new System.Drawing.Size(183, 42);
            this.btnHomeUser.TabIndex = 0;
            this.btnHomeUser.Text = "Tổng quan";
            this.btnHomeUser.UseVisualStyleBackColor = false;
            this.btnHomeUser.Click += new System.EventHandler(this.btnHomeUser_Click);
            // 
            // btnsogiaodich
            // 
            this.btnsogiaodich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnsogiaodich.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsogiaodich.ForeColor = System.Drawing.Color.White;
            this.btnsogiaodich.Location = new System.Drawing.Point(21, 138);
            this.btnsogiaodich.Name = "btnsogiaodich";
            this.btnsogiaodich.Size = new System.Drawing.Size(183, 42);
            this.btnsogiaodich.TabIndex = 1;
            this.btnsogiaodich.Text = "Sổ giao dịch";
            this.btnsogiaodich.UseVisualStyleBackColor = false;
            this.btnsogiaodich.Click += new System.EventHandler(this.btnsogiaodich_Click);
            // 
            // btnthuchi
            // 
            this.btnthuchi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnthuchi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthuchi.ForeColor = System.Drawing.Color.White;
            this.btnthuchi.Location = new System.Drawing.Point(21, 400);
            this.btnthuchi.Name = "btnthuchi";
            this.btnthuchi.Size = new System.Drawing.Size(183, 42);
            this.btnthuchi.TabIndex = 2;
            this.btnthuchi.Text = "Tổng thu chi";
            this.btnthuchi.UseVisualStyleBackColor = false;
            this.btnthuchi.Click += new System.EventHandler(this.btnthuchi_Click);
            // 
            // btnthongtin
            // 
            this.btnthongtin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnthongtin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthongtin.ForeColor = System.Drawing.Color.White;
            this.btnthongtin.Location = new System.Drawing.Point(21, 482);
            this.btnthongtin.Name = "btnthongtin";
            this.btnthongtin.Size = new System.Drawing.Size(183, 62);
            this.btnthongtin.TabIndex = 3;
            this.btnthongtin.Text = "Tài Khoản";
            this.btnthongtin.UseVisualStyleBackColor = false;
            this.btnthongtin.Click += new System.EventHandler(this.btnthongtin_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Image = ((System.Drawing.Image)(resources.GetObject("btnPlus.Image")));
            this.btnPlus.Location = new System.Drawing.Point(21, 225);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(183, 137);
            this.btnPlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPlus.TabIndex = 4;
            this.btnPlus.TabStop = false;
            // 
            // Sidebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnthongtin);
            this.Controls.Add(this.btnthuchi);
            this.Controls.Add(this.btnsogiaodich);
            this.Controls.Add(this.btnHomeUser);
            this.Name = "Sidebar";
            this.Size = new System.Drawing.Size(231, 585);
            ((System.ComponentModel.ISupportInitialize)(this.btnPlus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHomeUser;
        private System.Windows.Forms.Button btnsogiaodich;
        private System.Windows.Forms.Button btnthuchi;
        private System.Windows.Forms.Button btnthongtin;
        private System.Windows.Forms.PictureBox btnPlus;
    }
}
