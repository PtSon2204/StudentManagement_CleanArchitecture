using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using StudentManagement.Application.DTOs.DepartmentDtos;
using StudentManagement.Application.Interfaces;
using StudentManagement.Application.Services;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departList = await _departmentService.GetAllDepartment();

            if (departList == null)
            {
                return BadRequest("Empty!"); 
            }

            return Ok(departList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartById(string id)
        {
            var dept = await _departmentService.GetDepartmentById(id);

            if (dept == null)
            {
                return BadRequest($"Depart {id} not exists");
            }

            return Ok(dept);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDto dept)
        {
            await _departmentService.CreateDepartmentAsync(dept);

            return Created("", new { message = $"Created {dept.Name} successfully!"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(string id)
        {
            await _departmentService.DeleteDepartmentAsync(id);

            return Ok(new
            {
                message = $"{id} deleted successfully!"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(string id,  [FromBody] UpdateDepartmentDto dept)
        {
            if (id != dept.Id)
            {
                return BadRequest(new { message = "Id not match" });
            }

            await _departmentService.UpdateDepartmentAsync(dept);
            return Ok(new
            {
                message = $"{dept} update successfully!"
            });
        }
    }
}
