using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Crm.Sdk.Messages;
using StudentData.Core.IServices;
using StudentData.Core.Model;
using StudentDetail.Services;

namespace Student.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly IServices _services;
        public StudentApiController(IServices services)
        {
            _services = services;
        }

        #region Student Login
        [HttpPost]
        [Route("StudentLogIn")]
        public IActionResult StudentLogIn(StudentLogin login)
        {

            var logins = _services.StudentLogin(login);
            return Ok(logins);

        }
        #endregion

        #region Add SignUp Details
        [HttpPost]
        [Route("AddSignUPDetails")]
        public IActionResult AddSignUPDetails(UserDetail details)
        {
            var addUserDetail = _services.AddSignUpDetails(details);
            if (addUserDetail == true)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
        #endregion

        #region Student Dashboard
        [HttpGet]
        [Route("StudentDashBoard")]
        public IActionResult StudentDashBoard(int id)
        { 
            var getStudentList = _services.StudentDashBoard(id);
            return Ok(getStudentList);
        }
        #endregion

        #region Create And Update
        [HttpGet]
        [Route("SaveandUpdateStudentDetails")]
        public IActionResult SaveandUpdateStudentDetails(int studentId)
        {
            Studentmodel studentdetail = new Studentmodel();
            if (studentId > 0)
            {
                studentdetail = _services.GetStudentdetail(studentId);
                return Ok(studentdetail);
            }

            return Ok(studentdetail);
            
        }
       

        [HttpPost]
        [Route("SaveandUpdateStudentDetails")]
        public IActionResult SaveandUpdateStudentDetails(Studentmodel model)
        {

            var addStudent = _services.SaveandUpdateStudentDetails(model);
            if (addStudent == true)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
        #endregion

        #region Delete detail
        [HttpGet]
        [Route("Delete")]
        public ActionResult Delete(int studentId)
        {
            if (studentId > 0)
            {
                _services.Delete(studentId);
                return Ok(true);
            }
            
            else { return Ok(false); }
        }
        #endregion

    }
}