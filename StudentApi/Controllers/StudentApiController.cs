using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentData.Core.IServices;
using StudentData.Core.Model;

namespace StudentApi.Controllers
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
    }
}
