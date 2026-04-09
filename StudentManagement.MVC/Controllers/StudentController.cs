using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagement.MVC.Interfaces;
using StudentManagement.MVC.Models.Students;

namespace StudentManagement.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentApiService _studentApiService;
        private readonly IDepartmentApiService _departmentApiService;

        public StudentController(IStudentApiService studentApiService, IDepartmentApiService departmentApiService)
        {
            _studentApiService = studentApiService;
            _departmentApiService = departmentApiService;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var students = await _studentApiService.GetAllStudentsAsync();

        //    return View(students);
        //}

        public async Task<IActionResult> Create()
        {
            var list = await _departmentApiService.GetAll();
            ViewBag.Departments = new SelectList(list, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentVm student)
        {
            if (!ModelState.IsValid)
            {
                var list = await _departmentApiService.GetAll();
                ViewBag.Departments = new SelectList(list, "Id", "Name");
                return View(student);
            }

            await _studentApiService.Create(student);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var list = await _departmentApiService.GetAll();
            ViewBag.Departments = new SelectList(list, "Id", "Name");
            var student = await _studentApiService.GetStudentById(id);

            var model = new UpdateStudentVm
            {
                Id = student.Id,
                Name = student.Name,
                Gender = student.Gender,
                Dob = student.Dob,
                Gpa = student.Gpa,
                DepartmentId = student.DepartmentId
            };

            return View(model);
        }

        [HttpPost] 
        public async Task<IActionResult> Edit(int id, UpdateStudentVm student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            await _studentApiService.Update(id, student);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _studentApiService.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentApiService.GetStudentById(id);

            return View(student);
        }

        public async Task<IActionResult> Index(StudentQueryVm query)
        {
            var result = await _studentApiService.GetStudents(query);

            var departments = await _departmentApiService.GetAll();

            ViewBag.Departments = new SelectList(departments, "Name", "Name", query.Department);

            ViewBag.Query = query;

            return View(result);
        }
    }
}
