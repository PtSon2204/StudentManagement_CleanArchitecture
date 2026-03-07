using StudentManagement.MVC.Interfaces;
using StudentManagement.MVC.Models;

namespace StudentManagement.MVC.Services
{
    public class StudentApiService : IStudentApiService
    {
        public Task<IEnumerable<StudentVm>> GetAllStudentsAsync()
        {
            ///Gọi api backend

            return null;
        }
    }
}
