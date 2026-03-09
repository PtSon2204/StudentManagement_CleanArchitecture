using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Application.Common;
using StudentManagement.Application.DTOs.StudentDtos;
using StudentManagement.Application.Queries;

namespace StudentManagement.Application.Interfaces
{
    public interface IStudentService
    {
        Task<PagedResult<StudentDto>> GetStudents(StudentQuery query);
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto> GetByIdAsync(int id);
        Task CreateAsync(CreateStudentDto dto);
        Task<IEnumerable<StudentDto>> FilterStudents(string? name, bool? gender, DateTime? dob, double? gpa, string? dept);
        Task UpdateAsync(int id, UpdateStudentDto dto);
        Task DeleteAsync(int id);
    }
}
