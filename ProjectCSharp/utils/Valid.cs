using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSharp.Utils
{
    class Valid
    {
        public static void isEmail(string email)
        {
            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new Exception("Email không hợp lệ");
            }
        }
    }
}
