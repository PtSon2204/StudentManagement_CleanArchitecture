using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudentManagement.Application.Common;
using StudentManagement.Application.DTOs.StudentDtos;
using StudentManagement.Application.Interfaces;
using StudentManagement.Application.Queries;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.Interfaces;

namespace StudentManagement.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateStudentDto dto)
        {
            var newStudent = _mapper.Map<Student>(dto);

            newStudent.CreatedAt = DateTime.Now;
            newStudent.UpdatedAt = DateTime.Now;

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

            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var list = await _unitOfWork.StudentsRepo.GetAllStudents();

            return _mapper.Map<IEnumerable<StudentDto>>(list);
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var s = await _unitOfWork.StudentsRepo.GetStudentbyId(id);
            return _mapper.Map<StudentDto>(s);
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
        public async Task<PagedResult<StudentDto>> GetStudents(StudentQuery query)
        {
            var result = await _unitOfWork.StudentsRepo.GetStudents(query);

            return new PagedResult<StudentDto>
            {
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                TotalRecords = result.TotalRecords,
                TotalPages = result.TotalPages,

                Data = _mapper.Map<IEnumerable<StudentDto>>(result.Data)
            };
        }
    }
}
