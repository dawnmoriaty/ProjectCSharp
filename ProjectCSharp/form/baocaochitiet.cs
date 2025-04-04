﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectCSharp;
using ProjectCSharp.Model;

namespace ProjectCSharp
{
    
    public partial class baocaochitiet : UserControl
    {
        private User _user;
        public baocaochitiet(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BaoCao baoCaoForm = new BaoCao(_user);
            baoCaoForm.Show();
            this.Hide();
        }
    }
}
