using StudentData.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.Core.IRepository
{
    public interface IRepository
    {
        public int StudentLogin(StudentLogin login);
        public bool AddSignUpDetails(UserDetail details);
        bool SaveandUpdateStudentDetails(Studentmodel Studentmodel);
        List<Studentmodel> StudentDashBoard(int id);
        
        bool Delete(int id);
        Studentmodel GetStudentdetail(int id);

    }
}
