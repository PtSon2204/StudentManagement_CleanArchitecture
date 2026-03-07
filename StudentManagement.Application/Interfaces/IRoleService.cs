using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Application.DTOs.RoleDtos;
using StudentManagement.Domain.Entities;

namespace StudentManagement.Application.Interfaces
{
    public interface IRoleService
    {
        Task<RoleDto?> GetByIdAsync(int id);
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task AddAsync(CreateRoleDto dto);
        Task UpdateAsync(UpdateRoleDto dto);
        Task DeleteAsync(int id);
    }
}
