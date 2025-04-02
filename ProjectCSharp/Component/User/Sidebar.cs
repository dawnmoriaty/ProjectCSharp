using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCSharp.Component.User
{
    public partial class Sidebar: UserControl
    {
        private UsersHome usersHome;

        public Sidebar()
        {
            InitializeComponent();
        }
        public void setUsersForm(UsersHome information)
        {
            usersHome = information;
        }


        private void btnthongtin_Click(object sender, EventArgs e)
        {
            if (usersHome != null)
            {
                usersHome.ShowThongTinCanhan();
            }
            else
            {
                MessageBox.Show("Lỗi: UsersHome chưa được gán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnsogiaodich_Click(object sender, EventArgs e)
        {
            usersHome.ShowSoGiaoDich();
        }

        private void btnHomeUser_Click(object sender, EventArgs e)
        {
            usersHome.ShowHomePage();
        }
    }
}
