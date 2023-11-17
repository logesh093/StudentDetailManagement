using Microsoft.Crm.Sdk.Messages;
using StudentData.Core.IRepository;
using StudentData.Core.IServices;
using StudentData.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDetail.Services
{
    public class Services : IServices
    {

        private readonly IRepository _repository;
        public Services(IRepository repository)
        {
            _repository = repository;
        }
        public int StudentLogin(StudentLogin login)
        {
            return _repository.StudentLogin(login);
        }
        public bool AddSignUpDetails(UserDetail details)
        {
            return _repository.AddSignUpDetails(details);
        }
        public bool SaveandUpdateStudentDetails(Studentmodel model)
        {
            return _repository.SaveandUpdateStudentDetails(model);
        }
        public List<Studentmodel> StudentDashBoard(int id)
        {
            return _repository.StudentDashBoard( id);
        }
        public Studentmodel GetStudentdetail(int id)
        {
            return _repository.GetStudentdetail(id);
        }
        public bool Delete(int id)
        {

            return _repository.Delete(id);

        }
    }
}
