using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentData.Core.IServices
using StudentData.Core.IServices;

namespace StudentDatail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentapiController : ControllerBase
    {
        private readonly IServices _services;
        public StudentapiController(IServices services)
        {
            _services = services;
        }
        
        [HttpPost]
        [Route("StudentLogIn")]
        public IActionResult StudentLogIn(StudentLogin login)
        {

            var logins = _services.StudentLogin(login);
            if (logins == true)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }

        }













        [HttpGet]

        public IActionResult AddSignUPDetails()
        {
            
        }
        [HttpPost]

        public IActionResult AddSignUPDetails(StudentSignUp details)
        {
            var addStudent = _services.AddSignUpDetails(details);
            if (addStudent == true)
            {
                return RedirectToAction("StudentLogin");
            }
            else
            {
                ViewBag.Message = "Email Id Already Exist!!!";
                return View(details);
            }
        }
        public IActionResult StudentDashBoard()
        {
            List<Studentmodel> model = _services.StudentDashBoard();
            string message = TempData["Message"] != null ? TempData["Message"].ToString() : string.Empty;

            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.Message = message;
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult SaveandUpdateStudentDetails(int id)
        {
            Studentmodel model = new Studentmodel();
            if (id > 0)
            {
                model = _services.GetStudentdetail(id);
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public IActionResult SaveandUpdateStudentDetails(Studentmodel model)
        {

            if (model != null)
            {
                _services.SaveandUpdateStudentDetails(model);

                TempData["Meaasge"] = "Record Updated Successfully...";

            }
            else
            {
                TempData["Meaasge"] = "Record Created Successfully...";
            }

            return RedirectToAction("StudentDashBoard");
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                _services.Delete(id);
            }
            TempData["Meaasge"] = "Record Deleted Successfully...";
            return RedirectToAction("StudentDashBoard");
        }

        public IActionResult _Partialview(int id)
        {
            Studentmodel result = _services.GetStudentdetail(id);
            return PartialView(result);

        }
    }
}
