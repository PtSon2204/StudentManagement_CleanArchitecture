using Microsoft.AspNetCore.Mvc;
using StudentManagement.MVC.Interfaces;

namespace StudentManagement.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentApiService _studentService;

        public StudentController(IStudentApiService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
