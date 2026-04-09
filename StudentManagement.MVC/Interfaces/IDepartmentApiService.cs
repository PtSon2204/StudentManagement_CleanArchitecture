using StudentManagement.MVC.Models.Departments;

namespace StudentManagement.MVC.Interfaces
{
    public interface IDepartmentApiService
    {
        Task<IEnumerable<DepartmentVm>> GetAll();
        Task Create(CreateDepartmentVm department);
        Task Update(string id, UpdateDepartmentVm department);
        Task Delete(string id);    
        Task<DepartmentVm> GetById(string id);
    }
}
