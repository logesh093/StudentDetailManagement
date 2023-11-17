using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using StudentData.Core.Model;
using StudentData.Core.IRepository;
using StudentData.Core.IServices;
using StudentDetail.Services;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Net.Http.Json;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.AspNetCore.Http;

namespace StudentDetail.Controllers
{
    public class StudentController : Controller
    {

        #region Student login 
        [HttpGet]
        public IActionResult StudentLogIn()
        {
            HttpContext.Session.Clear();
            return View();
        }
        [HttpPost]
        public IActionResult StudentLogIn(StudentLogin loginDetail)
        {

            if (loginDetail.StudentEmailid != null && loginDetail.StudentPassword != null)
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5217/api/StudentApi/StudentLogIn");
                    var Posttask = client.PostAsJsonAsync<StudentLogin>(client.BaseAddress, loginDetail);
                    Posttask.Wait();
                    var checkresult = Posttask.Result;
                    int loginId = checkresult.Content.ReadFromJsonAsync<int>().Result;
                    if (loginId > 0)
                    {
                        
                        TempData["Message"] = "Login Succuessfully... ";
                        HttpContext.Session.SetString("UserId", (loginId).ToString());
                        return RedirectToAction("StudentDashBoard");
                    }
                    else
                    {
                        TempData["Message"] = "Incorrect Email or Password!!!";
                        return View();
                    }
                }

            }
            else
            {
                return RedirectToAction("StudentLogInPage");
            }
        }
        #endregion

        #region Add SignUp Details
        [HttpGet]

        public IActionResult AddSignUPDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSignUPDetails(UserDetail details)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5217/api/StudentApi/AddSignUPDetails");
                var Posttask = client.PostAsJsonAsync<UserDetail>(client.BaseAddress, details);
                Posttask.Wait();
                var checkresult = Posttask.Result;
                if(checkresult.IsSuccessStatusCode)
                {
                    var signupStatus = checkresult.Content.ReadFromJsonAsync<bool>().Result;
                    if (signupStatus == true)
                    {
                        TempData["SuccessMessage"] = "SignUp Successfully..";
                        return RedirectToAction("StudentLogIn");
                    }
                    else
                    {
                        ViewBag.Message = "Email Already Exist!!!";

                        return View("AddSignUPDetails");
                    }
                }
                return View("AddSignUPDetails");
            }
        }
        #endregion

        #region Student DashBoard
        public IActionResult StudentDashBoard()
        {
            using (var client = new HttpClient())
            {
                int id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                client.BaseAddress = new Uri($"http://localhost:5217/api/StudentApi/StudentDashBoard");

                var Posttask = client.GetAsync("StudentDashBoard?id=" + id);
                //var Posttask = client.GetAsync(client.BaseAddress);
                Posttask.Wait();
                var checkresult = Posttask.Result;
                if(checkresult.IsSuccessStatusCode)
                {
                    var result = checkresult.Content.ReadFromJsonAsync<List<Studentmodel>>().Result;

                    return View(result);
                }
                return View();

            }

        }
        #endregion

        #region Create and Update method
        [HttpGet]
        public IActionResult SaveandUpdateStudentDetails(int studentId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5217/api/StudentApi/SaveandUpdateStudentDetails");
                var Posttask = client.GetAsync("SaveandUpdateStudentDetails?studentId=" + studentId);
                Posttask.Wait();
                var checkresult = Posttask.Result;
                if(checkresult.IsSuccessStatusCode) 
                {
                    var studentdetails = checkresult.Content.ReadFromJsonAsync<Studentmodel>().Result;
                    if (studentdetails != null)
                    {

                        return View(studentdetails);
                    }
                    else
                    {
                        
                        return View();
                    }
                }
                return View();
            }
        }
        [HttpPost]
        public IActionResult SaveandUpdateStudentDetails(Studentmodel studentdetails)
        {
            if(studentdetails != null)
            {
                studentdetails.UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5217/api/StudentApi/SaveandUpdateStudentDetails");
                    var Posttask = client.PostAsJsonAsync<Studentmodel>(client.BaseAddress, studentdetails);
                    Posttask.Wait();
                    var checkresult = Posttask.Result;
                    if (checkresult.IsSuccessStatusCode)
                    {
                        var result = checkresult.Content.ReadFromJsonAsync<bool>().Result;
                        if (result == true)
                        {
                            TempData["Message"] = "New Rocord Created Successfully...";
                        }
                        else
                        {
                            TempData["Message"] = "Detail Updated Successfully...";
                        }
                    }
                  
                }
            }
            return RedirectToAction("StudentDashBoard");


        }


        #endregion

        #region Delete record
        public ActionResult Delete(int studentId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5217/api/StudentApi/Delete");
                var Posttask = client.GetAsync("Delete?studentId=" + studentId);
                Posttask.Wait();
                var checkresult = Posttask.Result;
              //  var result = checkresult.Content.ReadFromJsonAsync<bool>().Result;

                TempData["Message"] = "Rocord Deleted Successfully...";
                return RedirectToAction("StudentDashBoard");

            }
        }
        #endregion

        #region Partial view
        public IActionResult _Partialview(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5217/api/StudentApi/SaveandUpdateStudentDetails");
                var Posttask = client.GetAsync("SaveandUpdateStudentDetails?studentId=" + id);
                Posttask.Wait();
                var checkresult = Posttask.Result;
                var result = checkresult.Content.ReadFromJsonAsync<Studentmodel>().Result;
                return PartialView("_PartialView",result);
            }
               
        }
        #endregion
    }


}
