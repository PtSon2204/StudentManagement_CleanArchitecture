using StudentManagement.MVC.Models.Departments;

namespace StudentManagement.MVC.Interfaces
{
    public interface IDepartmentApiService
    {
        Task<IEnumerable<DepartmentVm>> GetAll();
    }
}
