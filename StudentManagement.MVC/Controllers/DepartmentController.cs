using Microsoft.AspNetCore.Mvc;
using StudentManagement.MVC.Interfaces;

namespace StudentManagement.MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentApiService _departmentApiService;

        public DepartmentController(IDepartmentApiService departmentApiService)
        {
            _departmentApiService = departmentApiService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _departmentApiService.GetAll();
            return View(list);
        }
    }
}
