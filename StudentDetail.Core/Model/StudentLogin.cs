using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.Core.Model
{
    public class StudentLogin
    {
        
        public string StudentEmailid { get; set; }
        
        public string StudentPassword { get; set; }
        public int UsersId { get; set; }

    }
}
