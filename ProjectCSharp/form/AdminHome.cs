using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCSharp
{
    public partial class AdminHome: Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void btnquanlytaikhoan_Click(object sender, EventArgs e)
        {

        }

        private void btnthongtincanhan_Click(object sender, EventArgs e)
        {
            danhmucgiaodich danhmucgiaodich = new danhmucgiaodich();
            danhmucgiaodich.Show(); 
        }
    }
}
