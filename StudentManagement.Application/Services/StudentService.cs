using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Application.DTOs.StudentDtos;
using StudentManagement.Application.Interfaces;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.Interfaces;

namespace StudentManagement.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateAsync(CreateStudentDto dto)
        {
            var now = DateTime.UtcNow;

            var newStudent = new Student
            {
                Name = dto.Name,
                Gender = dto.Gender,
                Gpa = dto.Gpa,
                DepartmentId = dto.DepartmentId,
                CreatedAt = now,
                UpdatedAt = now,
                Dob = dto.Dob,
            };

            await _unitOfWork.StudentsRepo.CreateStudent(newStudent);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var st = await _unitOfWork.StudentsRepo.GetStudentbyId(id);

            if (st == null)
            {
                throw new Exception("St not exist");
            }

            _unitOfWork.StudentsRepo.DeleteStudent(st);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<StudentDto>> FilterStudents(string? name, bool? gender, DateTime? dob, double? gpa, string? dept)
        {
            var students = await _unitOfWork.StudentsRepo.FilterStudent(name, gender, dob, gpa, dept);

            return students.Select(s => new StudentDto
            {
                Name = s.Name,
                Gender = s.Gender,
                Gpa = s.Gpa,
                Dob= s.Dob,
                DepartmentName = s.Department.Name
            });
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var list = await _unitOfWork.StudentsRepo.GetAllStudents();

            return list.Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Gender = s.Gender,
                Gpa = s.Gpa,
                Dob = s.Dob,
                DepartmentId = s.DepartmentId,
                DepartmentName = s.Department.Name,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt,
            });
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var s = await _unitOfWork.StudentsRepo.GetStudentbyId(id);
            return new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Gender = s.Gender,
                Gpa = s.Gpa,
                Dob = s.Dob,
                DepartmentId = s.DepartmentId,
                DepartmentName = s.Department.Name,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt,
            };
        }

        public async Task UpdateAsync(int id, UpdateStudentDto dto)
        {
            var st = await _unitOfWork.StudentsRepo.GetStudentbyId(id);

            if (st == null)
            {
                throw new Exception("Not found!");
            }

            st.Name = dto.Name;
            st.Gender = dto.Gender;
            st.Gpa = dto.Gpa;
            st.Dob = dto.Dob;
            st.DepartmentId = dto.DepartmentId;

            _unitOfWork.StudentsRepo.UpdateStudent(st);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
