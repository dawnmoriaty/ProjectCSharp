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
    public partial class sogiaodich : UserControl
    {
        private static sogiaodich _instance;

        public static sogiaodich Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new sogiaodich();
                return _instance;
            }
        }
        public sogiaodich()
        {
            InitializeComponent();
        }

        private void btnPresent_Click(object sender, EventArgs e)
        {

        }

        private void btnFuture_Click(object sender, EventArgs e)
        {

        }

        private void btnPast_Click(object sender, EventArgs e)
        {

        }

        
    }
}
