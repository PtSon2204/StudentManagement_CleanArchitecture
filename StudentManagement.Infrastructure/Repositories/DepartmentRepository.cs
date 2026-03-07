using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.Interfaces;
using StudentManagement.Infrastructure.Data;

namespace StudentManagement.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private ApplicationDbContext context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddDepartment(Department department)
        {
             await context.Departments.AddAsync(department);
        }

        public void DeleteDepartment(Department department)
        {
            context.Remove(department);
        }

        public async Task<IEnumerable<Department>> GetAllDepartment()
        {
            return await context.Departments.ToListAsync();
        }

        public async Task<Department?> GetDepartmentById(string id)
        {
            return await context.Departments.FindAsync(id);
        }

        public async Task<Department?> GetDepartmentByName(string name)
        {
            return await context.Departments.FindAsync(name);
        }

        public void UpdateDepartment(Department department)
        {
            context.Update(department);
        }
    }
}
