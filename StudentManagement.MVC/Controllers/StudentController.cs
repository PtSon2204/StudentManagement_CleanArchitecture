using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.MVC.Interfaces;
using StudentManagement.MVC.Models;

namespace StudentManagement.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentApiService _studentApiService;

        public StudentController(IStudentApiService studentApiService)
        {
            _studentApiService = studentApiService;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentApiService.GetAllStudentsAsync();

            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentVm student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            await _studentApiService.Create(student);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentApiService.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost] 
        public async Task<IActionResult> Edit(int id, StudentVm student)
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
    }
}
