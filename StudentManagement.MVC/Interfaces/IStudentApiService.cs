using StudentManagement.MVC.Models;

namespace StudentManagement.MVC.Interfaces
{
    public interface IStudentApiService
    {
        Task<IEnumerable<StudentVm>> GetAllStudentsAsync();
        Task<StudentVm> GetStudentById(int id);

        Task Create(StudentVm student);

        Task Update(int id, StudentVm student);

        Task DeleteStudent(int id);

        Task<List<StudentVm>> FilterStudents(string? name, bool? gender, DateTime? dob, double? gpa, string? dept);
    }
}
