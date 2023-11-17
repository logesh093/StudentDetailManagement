using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.Core.Model
{
    public class UserDetail
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Phonenumber { get; set; }

        public string UserEmailid { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


       
    }
}
