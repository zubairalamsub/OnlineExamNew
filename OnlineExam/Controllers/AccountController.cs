using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Entity;
using OnlineExam.Entity.ViewModel;
using OnlineExam.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace OnlineExam.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILoginService _loginService;
        private readonly ITeacherService _teacherService;

        public AccountController(ILoginService loginService,ITeacherService teacherService)
        {
            _loginService = loginService;
            _teacherService = teacherService;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        public IActionResult TeacherLogin()
        {

            return View();
        }
        public IActionResult CreateTeacher()
        {
            return View();
        }
        public IActionResult LinkNotFound()
        {
            return View();
        }

        public IActionResult AdminHome()
        {
            return View();
        }



        [HttpPost]
        [Route("api/UserRegister")]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UserRegister([FromBody] StudentVM student)
        {
            var response = new ListResponseModel<Student>();

            try
            {

                var data = await _loginService.UserRegister(student);
                response.Model = data;
            }
            catch (Exception exp)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }

            return response.ToHttpResponse();
        }

        [HttpGet]
        [Route("api/LoadAllteacher")]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> loadAllTeacher()
        {
            var response = new ListResponseModel<Teacher>();

            try
            {

                var data = await _loginService.LoadAllTeacher();
                response.Model = data;
            }
            catch (Exception exp)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }

            return response.ToHttpResponse();
        }


        [HttpPost]
        [Route("api/TeacherRegister")]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> TeacherRegister([FromBody] Teacher teacher)
        {
            var response = new SingleResponseModel<Teacher>();

            try
            {

                var data = await _loginService.TeacherRegister(teacher);
                response.Model = data;
            }
            catch (Exception exp)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }

            return response.ToHttpResponse();
        }

        [HttpPost]
        [Route("api/UpdateStudent")]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            var response = new SingleResponseModel<Student>();

            try
            {

                var data = await _loginService.UpdateStudent(student);
                response.Model = data;
            }
            catch (Exception exp)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }

            return response.ToHttpResponse();
        }


        [HttpPost]
        [Route("api/CheckLinkValidity")]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CheckLinkValidity([FromBody] Student student)
        {
            var response = new SingleResponseModel<Student>();

            try
            {

                var data = await _loginService.CheckLinkValidity(student);
                response.Model = data;
            }
            catch (Exception exp)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }

            return response.ToHttpResponse();
        }

        [HttpPost]
        [Route("api/Teacherlogin")]
        public async Task<bool> Index([FromBody] loginViewModel userlogIn)
        {
            try
            {
                var user = await _loginService.GetAllTeacher(userlogIn);
                if (user != null)
                {

                    HttpContext.Session.SetInt32("Id", user.Id);
                    HttpContext.Session.SetString("UserName", user.UserName);
                    HttpContext.Session.SetString("Password", user.Password);
                    HttpContext.Session.SetInt32("AdminType", Convert.ToInt32(user.AdminType));
                    HttpContext.Session.SetString("LoginType", "Teacher");
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddMinutes(1000);
                    Response.Cookies.Append("Id", user.Id.ToString(), option);
                    Response.Cookies.Append("UserName", user.UserName, option);
                    Response.Cookies.Append("Password", user.Password, option);
                    Response.Cookies.Append("AdminType", user.AdminType.ToString(), option);
                    Response.Cookies.Append("LoginType", "Teacher", option);
                    Response.Cookies.Append("teacherfullName", user.Name, option);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        



        [HttpPost]
        [Route("api/Studentlogin")]
        public async Task<bool> StudentLogin([FromBody] loginViewModel userlogIn)
        {
            try
            {
                var user = await _loginService.GetAllStudent(userlogIn);
                if (user != null)
                {

                    HttpContext.Session.SetInt32("StudentId", user.Id);
                    HttpContext.Session.SetString("StudentUserName", user.UserName);
                    HttpContext.Session.SetString("StudentPassword", user.Password);
                    HttpContext.Session.SetString("StudentClassId", user.ClassId.ToString());
                    //HttpContext.Session.SetInt32("AdminType", Convert.ToInt32(user.AdminType));
                    HttpContext.Session.SetString("LoginType", "Student");
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddMinutes(1000);
                    Response.Cookies.Append("StudentId", user.Id.ToString(), option);
                    Response.Cookies.Append("StudentUserName", user.UserName, option);
                    Response.Cookies.Append("StudentPassword", user.Password, option);
                    Response.Cookies.Append("StudentClassId", user.ClassId.ToString(), option);
                    //Response.Cookies.Append("AdminType", user.AdminType.ToString(), option);
                    Response.Cookies.Append("LoginType", "Student", option);
                    Response.Cookies.Append("StudentfullName", user.Name, option);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public IActionResult LogOut()
        {
            //Session.Remove("loggedinUser");
            //var cookie = ControllerContext.HttpContext.Request.Cookies["userid"];
            //cookie.Expires = DateTime.Now.AddDays(-1);
            //Response.Cookies.Add(cookie);
            HttpContext.Session.Clear();
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(-1);
            Response.Cookies.Delete("Id");
            Response.Cookies.Delete("UserName");
            Response.Cookies.Delete("Password");
            //Response.Cookies.Delete("AdminType");
            //Response.Cookies.Delete("LoginType");
            Response.Cookies.Delete("teacherfullName");
            return RedirectToAction("TeacherLogin", "Home");
        }


        public IActionResult StudentLogOut()
        {
            //Session.Remove("loggedinUser");
            //var cookie = ControllerContext.HttpContext.Request.Cookies["userid"];
            //cookie.Expires = DateTime.Now.AddDays(-1);
            //Response.Cookies.Add(cookie);
            HttpContext.Session.Clear();
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(-1);
            Response.Cookies.Delete("StudentId");
            Response.Cookies.Delete("StudentUserName");
            Response.Cookies.Delete("StudentPassword");
            //Response.Cookies.Delete("AdminType");
            //Response.Cookies.Delete("LoginType");
            Response.Cookies.Delete("StudentfullName");
            return RedirectToAction("StudentLogin", "Home");
        }






    }
}
