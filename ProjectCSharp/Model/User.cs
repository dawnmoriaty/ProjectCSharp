using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSharp.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; } = "USER";
        private bool Status { get;  set; } = true;
        private DateTime CreatedAt { get; set; }
    }
}
