using StudentManagement.MVC.Models;

namespace StudentManagement.MVC.Interfaces
{
    public interface IStudentApiService
    {
        Task<IEnumerable<StudentVm>> GetAllStudentsAsync();
    }
}
