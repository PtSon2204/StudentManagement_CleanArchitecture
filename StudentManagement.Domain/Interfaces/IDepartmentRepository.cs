using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Application.Common;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.Queries;

namespace StudentManagement.Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department?> GetDepartmentById(string id);
        Task<Department?> GetDepartmentByName(string name);
        Task<IEnumerable<Department>> GetAllDepartment();
        Task AddDepartment(Department department);
        void DeleteDepartment(Department department);
        void UpdateDepartment(Department department);
        Task<PagedResult<Department>> GetAllDepartmentPagedResults(DepartmentQuery query);
    }
}
