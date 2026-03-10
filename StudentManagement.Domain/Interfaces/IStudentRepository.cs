using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Application.Common;
using StudentManagement.Application.Queries;
using StudentManagement.Domain.Entities;

namespace StudentManagement.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<PagedResult<Student>> GetStudents(StudentQuery query);
        Task<Student?> GetStudentbyId(int id);
        Task<IEnumerable<Student>> FilterStudent(string? name, bool? gender, DateTime? dob, double? gpa, string? dept);
        Task CreateStudent(Student student);
        void UpdateStudent(Student student);    
        void DeleteStudent(Student student);
    }
}
