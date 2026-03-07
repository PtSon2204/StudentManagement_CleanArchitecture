using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Application.DTOs.RoleDtos;
using StudentManagement.Application.Interfaces;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.Interfaces;

namespace StudentManagement.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ================= GET BY ID =================
        public async Task<RoleDto?> GetByIdAsync(int id)
        {
            var role = await _unitOfWork.RoleRepo.GetByIdAsync(id);

            if (role == null) return null;

            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                CreatedAt = role.CreatedAt,
                UpdatedAt = role.UpdatedAt
            };
        }

        // ================= GET ALL =================
        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var roles = await _unitOfWork.RoleRepo.GetAllAsync();

            return roles.Select(role => new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                CreatedAt = role.CreatedAt,
                UpdatedAt = role.UpdatedAt
            });
        }

        // ================= CREATE =================
        public async Task AddAsync(CreateRoleDto dto)
        {
            var now = DateTime.UtcNow;

            var newRole = new Role
            {
                Name = dto.Name,
                CreatedAt = now,
                UpdatedAt = now
            };

            await _unitOfWork.RoleRepo.AddAsync(newRole);
            await _unitOfWork.SaveChangesAsync();
        }

        // ================= UPDATE =================
        public async Task UpdateAsync(UpdateRoleDto dto)
        {
            var existingRole = await _unitOfWork.RoleRepo.GetByIdAsync(dto.Id);

            if (existingRole == null)
                throw new Exception("Role not found");

            existingRole.Name = dto.Name;
            existingRole.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.RoleRepo.Update(existingRole);
            await _unitOfWork.SaveChangesAsync();
        }

        // ================= DELETE =================
        public async Task DeleteAsync(int id)
        {
            var role = await _unitOfWork.RoleRepo.GetByIdAsync(id);

            if (role == null)
                throw new Exception("Role not found");

            _unitOfWork.RoleRepo.Delete(role);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
