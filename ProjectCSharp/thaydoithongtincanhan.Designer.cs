namespace ProjectCSharp
{
    partial class thaydoithongtincanhan
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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTenthaydoi = new System.Windows.Forms.TextBox();
            this.txtemailthaydoi = new System.Windows.Forms.TextBox();
            this.btnChangeInformation = new System.Windows.Forms.Button();
            this.btnExitChangeInformation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(204, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(374, 32);
            this.label7.TabIndex = 1;
            this.label7.Text = "Thay đổi thông tin cá nhân";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(61, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 25);
            this.label8.TabIndex = 2;
            this.label8.Text = "Tên người dùng: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(71, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 25);
            this.label9.TabIndex = 3;
            this.label9.Text = "Email: ";
            // 
            // txtTenthaydoi
            // 
            this.txtTenthaydoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenthaydoi.Location = new System.Drawing.Point(290, 123);
            this.txtTenthaydoi.Name = "txtTenthaydoi";
            this.txtTenthaydoi.Size = new System.Drawing.Size(318, 30);
            this.txtTenthaydoi.TabIndex = 4;
            // 
            // txtemailthaydoi
            // 
            this.txtemailthaydoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemailthaydoi.Location = new System.Drawing.Point(290, 186);
            this.txtemailthaydoi.Name = "txtemailthaydoi";
            this.txtemailthaydoi.Size = new System.Drawing.Size(318, 30);
            this.txtemailthaydoi.TabIndex = 5;
            // 
            // btnChangeInformation
            // 
            this.btnChangeInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnChangeInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeInformation.ForeColor = System.Drawing.Color.White;
            this.btnChangeInformation.Location = new System.Drawing.Point(210, 269);
            this.btnChangeInformation.Name = "btnChangeInformation";
            this.btnChangeInformation.Size = new System.Drawing.Size(292, 48);
            this.btnChangeInformation.TabIndex = 6;
            this.btnChangeInformation.Text = "Cập nhật";
            this.btnChangeInformation.UseVisualStyleBackColor = false;
            this.btnChangeInformation.Click += new System.EventHandler(this.btnChangeInformation_Click);
            // 
            // btnExitChangeInformation
            // 
            this.btnExitChangeInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExitChangeInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitChangeInformation.ForeColor = System.Drawing.Color.White;
            this.btnExitChangeInformation.Location = new System.Drawing.Point(210, 351);
            this.btnExitChangeInformation.Name = "btnExitChangeInformation";
            this.btnExitChangeInformation.Size = new System.Drawing.Size(292, 48);
            this.btnExitChangeInformation.TabIndex = 7;
            this.btnExitChangeInformation.Text = "Thoát";
            this.btnExitChangeInformation.UseVisualStyleBackColor = false;
            this.btnExitChangeInformation.Click += new System.EventHandler(this.btnExitChangeInformation_Click);
            // 
            // thaydoithongtincanhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExitChangeInformation);
            this.Controls.Add(this.btnChangeInformation);
            this.Controls.Add(this.txtemailthaydoi);
            this.Controls.Add(this.txtTenthaydoi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Name = "thaydoithongtincanhan";
            this.Size = new System.Drawing.Size(764, 508);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTenthaydoi;
        private System.Windows.Forms.TextBox txtemailthaydoi;
        private System.Windows.Forms.Button btnChangeInformation;
        private System.Windows.Forms.Button btnExitChangeInformation;
    }
}
