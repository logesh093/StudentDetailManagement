using StudentData.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.Core.IServices
{
    public interface IServices
    {
        public int StudentLogin(StudentLogin login);
        public bool AddSignUpDetails(UserDetail details);
        public bool SaveandUpdateStudentDetails(Studentmodel model);
        public List<Studentmodel> StudentDashBoard(int id);
        public Studentmodel GetStudentdetail(int id);

        public bool Delete(int id);     
    }
}
