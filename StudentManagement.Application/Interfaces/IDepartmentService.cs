using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Application.DTOs.DepartmentDtos;

namespace StudentManagement.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllDepartment();
        Task<DepartmentDto?> GetDepartmentById(string id);
        Task CreateDepartmentAsync(CreateDepartmentDto department);
        Task UpdateDepartmentAsync(UpdateDepartmentDto department);
        Task DeleteDepartmentAsync(string id);
    }
}
