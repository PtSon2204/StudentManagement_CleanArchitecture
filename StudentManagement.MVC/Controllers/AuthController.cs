using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.MVC.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
