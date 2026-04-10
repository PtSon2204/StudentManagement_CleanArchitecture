using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagement.MVC.Interfaces;
using StudentManagement.MVC.Models.Departments;
using StudentManagement.MVC.Models.Students;
using StudentManagement.MVC.Services;

namespace StudentManagement.MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentApiService _departmentApiService;

        public DepartmentController(IDepartmentApiService departmentApiService)
        {
            _departmentApiService = departmentApiService;
        }
        //public async Task<IActionResult> Index()
        //{
        //    var list = await _departmentApiService.GetAll();
        //    return View(list);
        //}
        public async Task<IActionResult> Index(DepartmentQueryVm query)
        {
            var result = await _departmentApiService.FilterAllAsync(query);

            ViewBag.Query = query;

            return View(result);
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
        public async Task<IActionResult> Update(string id)
        {
            var dept = await _departmentApiService.GetById(id);
            if (dept == null)
            {
                return View("Error");
            }

            var updateModel = new UpdateDepartmentVm
            {
                Id = dept.Id,
                Name = dept.Name
            };
            return View(updateModel);
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
