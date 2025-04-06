namespace ProjectCSharp
{
    partial class UsersHome
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.sidebar1 = new ProjectCSharp.Component.User.Sidebar();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel.Location = new System.Drawing.Point(172, 2);
            this.panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(812, 579);
            this.panel.TabIndex = 1;
            // 
            // sidebar1
            // 
            this.sidebar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(181)))), ((int)(((byte)(114)))));
            this.sidebar1.Location = new System.Drawing.Point(-5, 1);
            this.sidebar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sidebar1.Name = "sidebar1";
            this.sidebar1.Size = new System.Drawing.Size(173, 580);
            this.sidebar1.TabIndex = 1;
            this.sidebar1.Load += new System.EventHandler(this.sidebar1_Load);
            // 
            // UsersHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 583);
            this.Controls.Add(this.sidebar1);
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UsersHome";
            this.Text = "UsersHome";
            this.Load += new System.EventHandler(this.UsersHome_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Component.User.Sidebar sidebar1;
        private System.Windows.Forms.Panel panel;
    }
}