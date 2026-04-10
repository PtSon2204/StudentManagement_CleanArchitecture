using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Application.Common;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.Interfaces;
using StudentManagement.Domain.Queries;
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

        public async Task<PagedResult<Department>> GetAllDepartmentPagedResults(DepartmentQuery query)
        {
            var dept = context.Departments.AsQueryable();

            if (!string.IsNullOrEmpty(query.Name))
            {
                dept = dept.Where(x => x.Name == query.Name);
            }

            if (query.StartDate.HasValue)
            {
                dept = dept.Where(x => x.UpdatedAt >= query.StartDate.Value);
            }

            if (query.EndDate.HasValue)
            {
                dept = dept.Where(x => x.UpdatedAt <= query.EndDate.Value);
            }

            var totalRecords = await dept.CountAsync();

            var data = await dept.Skip((query.PageNumber - 1) * query.PageSize)
                                 .Take(query.PageSize)
                                 .ToListAsync();

            return new PagedResult<Department>
            {
                Data = data,
                PageNumber = query.PageNumber,
                PageSize = query.PageSize,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)query.PageSize)
            };
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
