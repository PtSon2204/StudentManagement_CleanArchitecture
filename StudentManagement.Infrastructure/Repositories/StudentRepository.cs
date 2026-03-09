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
            return await context.Students.Include(s => s.Department).ToListAsync();
        }

        public async Task<Student?> GetStudentbyId(int id)
        {
            return await context.Students.Include(s => s.Department).FirstOrDefaultAsync(s => s.Id == id);
        }

        public void UpdateStudent(Student student)
        {
            context.Students.Update(student);
        }
    }
}
