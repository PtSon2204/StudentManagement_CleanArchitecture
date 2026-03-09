using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Application.DTOs.DepartmentDtos;
using StudentManagement.Application.Interfaces;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.Interfaces;

namespace StudentManagement.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateDepartmentAsync(CreateDepartmentDto department)
        {
            var now = DateTime.UtcNow;
            var exist = await _unitOfWork.DepartmentRepo.GetDepartmentByName(department.Name);

            if (exist != null)
            {
                throw new Exception("Department already exists");
            }

            var newDeparment = new Department
            {
                Id = department.Id,
                Name = department.Name,
                CreatedAt = now,
                UpdatedAt = now
            };
            
            await _unitOfWork.DepartmentRepo.AddDepartment(newDeparment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(string id)
        {
            var department = await _unitOfWork.DepartmentRepo.GetDepartmentById(id);

            _unitOfWork.DepartmentRepo.DeleteDepartment(department);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartment()
        {
            var departmentList = await _unitOfWork.DepartmentRepo.GetAllDepartment();

            return departmentList.Select(department => new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                CreatedAt = department.CreatedAt,
                UpdatedAt = department.UpdatedAt
            });
        }

        public async Task<DepartmentDto?> GetDepartmentById(string id)
        {
            var d = await _unitOfWork.DepartmentRepo.GetDepartmentById(id);

            if (d == null)
            {
                throw new ArgumentException($"Not found department by Id: {id}");
            }

            return new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt
            };
        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentDto department)
        {
            var upDepart = await _unitOfWork.DepartmentRepo.GetDepartmentById(department.Id);

            if (upDepart == null)
            {
                throw new ArgumentException($"Not found department by Id: {department.Id}");
            }

            upDepart.Name = department.Name;
            upDepart.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.DepartmentRepo.UpdateDepartment(upDepart);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
