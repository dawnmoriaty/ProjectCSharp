using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectCSharp.Model;

namespace ProjectCSharp
{
    public partial class homepage: UserControl
    {
        private User currentUser;
        private UsersHome usersHome;
        public homepage()
        {
            InitializeComponent();
        }
        public homepage(User user, UsersHome usersHome)
        {
            InitializeComponent();
            this.currentUser = user;
            this.usersHome = usersHome;
        }
    }
}
