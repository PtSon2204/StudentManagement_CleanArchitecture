using StudentManagement.MVC.Common;
using StudentManagement.MVC.Models.Students;

namespace StudentManagement.MVC.Interfaces
{
    public interface IStudentApiService
    {
        Task<IEnumerable<StudentVm>> GetAllStudentsAsync();
        Task<StudentVm> GetStudentById(int id);

        Task Create(CreateStudentVm student);

        Task Update(int id, UpdateStudentVm student);

        Task DeleteStudent(int id);

        Task<List<StudentVm>> FilterStudents(string? name, bool? gender, DateTime? dob, double? gpa, string? dept);
        Task<PagedResult<StudentVm>> GetStudents(StudentQueryVm query);
    }
}
