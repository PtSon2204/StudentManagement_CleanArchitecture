using Microsoft.AspNetCore.Mvc;
using StudentManagement.MVC.Interfaces;
using StudentManagement.MVC.Models.Departments;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]      
        
        public async Task<IActionResult> Create(CreateDepartmentVm departmentVm)
        {
           if (!ModelState.IsValid)
            {
                return View(departmentVm);
            }

            await _departmentApiService.Create(departmentVm);

            return RedirectToAction("Index");   
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            var dept = _departmentApiService.GetById(id);
            return View(dept);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, UpdateDepartmentVm updateDepartmentVm)
        {
            if (!ModelState.IsValid)
            {
                return View(updateDepartmentVm);
            }

            await _departmentApiService.Update(id,  updateDepartmentVm);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await _departmentApiService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
