using StudentManagement.MVC.Models;

namespace StudentManagement.MVC.Interfaces
{
    public interface IRoleApiService
    {
        Task<List<RoleVm>> GetAll();

        Task<RoleVm> GetById(int id);

        Task Create(RoleVm role);

        Task Update(int id, RoleVm role);

        Task Delete(int id);
    }
}
