using Microsoft.AspNetCore.Mvc;
using StudentManagement.MVC.Interfaces;
using StudentManagement.MVC.Models;

namespace StudentManagement.MVC.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleApiService _roleService;

        public RoleController(IRoleApiService roleService)
        {
            _roleService = roleService;
        }

        // LIST
        public async Task<IActionResult> Index()
        {
            var roles = await _roleService.GetAll();
            return View(roles);
        }

        // GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST CREATE
        [HttpPost]
        public async Task<IActionResult> Create(RoleVm roleVm)
        {
            if (!ModelState.IsValid)
                return View(roleVm);

            await _roleService.Create(roleVm);

            return RedirectToAction(nameof(Index));
        }

        // GET EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var role = await _roleService.GetById(id);

            if (role == null)
                return NotFound();

            return View(role);
        }

        // POST EDIT
        [HttpPost]
        public async Task<IActionResult> Edit(int id, RoleVm roleVm)
        {
            if (!ModelState.IsValid)
                return View(roleVm);

            await _roleService.Update(id, roleVm);

            return RedirectToAction(nameof(Index));
        }

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            await _roleService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

