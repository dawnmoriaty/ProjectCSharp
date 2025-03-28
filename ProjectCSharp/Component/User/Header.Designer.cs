namespace ProjectCSharp.Component.User
{
    partial class Header
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Header));
            this.btnthemchitieu = new System.Windows.Forms.Button();
            this.btnthemkhoanthu = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnthemchitieu
            // 
            this.btnthemchitieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnthemchitieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthemchitieu.ForeColor = System.Drawing.Color.White;
            this.btnthemchitieu.Location = new System.Drawing.Point(697, 36);
            this.btnthemchitieu.Name = "btnthemchitieu";
            this.btnthemchitieu.Size = new System.Drawing.Size(225, 71);
            this.btnthemchitieu.TabIndex = 0;
            this.btnthemchitieu.Text = "Thêm chi tiêu";
            this.btnthemchitieu.UseVisualStyleBackColor = false;
            // 
            // btnthemkhoanthu
            // 
            this.btnthemkhoanthu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.btnthemkhoanthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthemkhoanthu.ForeColor = System.Drawing.Color.White;
            this.btnthemkhoanthu.Location = new System.Drawing.Point(426, 36);
            this.btnthemkhoanthu.Name = "btnthemkhoanthu";
            this.btnthemkhoanthu.Size = new System.Drawing.Size(225, 71);
            this.btnthemkhoanthu.TabIndex = 1;
            this.btnthemkhoanthu.Text = "Thêm khoản thu";
            this.btnthemkhoanthu.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(34, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Header
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnthemkhoanthu);
            this.Controls.Add(this.btnthemchitieu);
            this.Name = "Header";
            this.Size = new System.Drawing.Size(1007, 150);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnthemchitieu;
        private System.Windows.Forms.Button btnthemkhoanthu;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
