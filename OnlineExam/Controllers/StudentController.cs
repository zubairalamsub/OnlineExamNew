using Microsoft.AspNetCore.Mvc;

namespace OnlineExam.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
