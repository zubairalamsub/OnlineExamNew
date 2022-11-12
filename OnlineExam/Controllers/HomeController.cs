using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LandingPage()
        {
            return View();
        }
        public IActionResult Exam()
        {
            int teacherId = GetStudentIdFromCookie();
            if (teacherId > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("StudentLogin", "Home");
            }

        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TeacherLogin ()
        {
            return View();
        }

        public IActionResult StudentLogin()
        {

            return View();
        }

        public IActionResult AdminLogin()
        {
            return View();
        }

        public int GetStudentIdFromCookie()
        {
            try
            {
                var userid = Convert.ToInt32(ControllerContext.HttpContext.Request.Cookies["StudentId"]);
                return userid;
            }
            catch (Exception ex)

            {

                throw ex;
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
