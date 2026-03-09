using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Application.DTOs.StudentDtos;
using StudentManagement.Application.Interfaces;
using StudentManagement.Application.Queries;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _studentService.GetAllAsync();

            if (result == null)
            {
                return NotFound("List empty!");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var result = await _studentService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound($"{id} not exist!");
            }

            return Ok(result);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterStudents(string? name, bool? gender, DateTime? dob, double? gpa, string? dept)
        {
            var result = await _studentService.FilterStudents(name, gender, dob, gpa, dept);

            if (!result.Any())
            {
                return NotFound("List empty!");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto st)
        {
            await _studentService.CreateAsync(st);

            return Created("", new
            {
                message = $"Created {st.Name} successfully!"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentDto st)
        {
            await _studentService.UpdateAsync(id, st);

            return Ok(new
            {
                message = $"Update {st.Name} successfully!" 
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteAsync(id);

            return Ok(new
            {
                message = $"Delete {id} successfully!"
            });
        }

        [HttpGet("Pagination")]
        public async Task<IActionResult> GetStudents([FromQuery] StudentQuery query)
        {
            var result = await _studentService.GetStudents(query);

            return Ok(result);
        }
    }
}
