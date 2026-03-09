using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Application.Common;
using StudentManagement.Application.Queries;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.Interfaces;
using StudentManagement.Infrastructure.Data;

namespace StudentManagement.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private ApplicationDbContext context;

        public StudentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateStudent(Student student)
        {
            await context.Students.AddAsync(student);
        }

        public void DeleteStudent(Student student)
        {
            context.Students.Remove(student);
        }

        public async Task<IEnumerable<Student>> FilterStudent(string? name, bool? gender, DateTime? dob, double? gpa, string? dept)
        {
            var query = context.Students.Include(s => s.Department).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query  = query.Where(s => s.Name.ToLower().Contains(name.ToLower()));
            }

            if(gender.HasValue)
            {
                query = query.Where(s => s.Gender == gender);
            }

            if(dob.HasValue)
            {
                query = query.Where(s => s.Dob == dob);
            }

            if (gpa.HasValue)
            {
                query = query.Where(s => s.Gpa == gpa);
            }

            if (!string.IsNullOrEmpty(dept))
            {
                query = query.Where(s => s.Department.Name.Contains(dept));
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await context.Students.Include(s => s.Department).AsNoTracking().ToListAsync();
        }

        public async Task<Student?> GetStudentbyId(int id)
        {
            return await context.Students.Include(s => s.Department).AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<PagedResult<Student>> GetStudents(StudentQuery query)
        {
            var students = context.Students
                .Include(s => s.Department)
                .AsQueryable();

            if (!string.IsNullOrEmpty(query.Name))
            {
                students = students.Where(s => s.Name.ToLower()
                .Contains(query.Name.ToLower()));
            }

            if (query.Gender.HasValue)
            {
                students = students.Where(s => s.Gender == query.Gender);
            }

            if (query.Dob.HasValue)
            {
                students = students.Where(s => s.Dob == query.Dob);
            }

            if (query.Gpa.HasValue)
            {
                students = students.Where(s => s.Gpa == query.Gpa);
            }

            if (!string.IsNullOrEmpty(query.Department))
            {
                students = students.Where(s =>
                    s.Department.Name.Contains(query.Department));
            }

            var totalRecords = await students.CountAsync();

            var data = await students
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

            return new PagedResult<Student>
            {
                Data = data,
                PageNumber = query.PageNumber,
                PageSize = query.PageSize,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)query.PageSize)
            };
        }

        public void UpdateStudent(Student student)
        {
            context.Students.Update(student);
        }
    }
}
