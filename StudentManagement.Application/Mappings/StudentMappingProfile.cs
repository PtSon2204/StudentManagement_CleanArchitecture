using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using StudentManagement.Application.DTOs.StudentDtos;
using StudentManagement.Domain.Entities;
using AutoMapper;

namespace StudentManagement.Application.Mappings
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.DepartmentName,
                    opt => opt.MapFrom(src => src.Department.Name));

            CreateMap<CreateStudentDto, Student>();

            CreateMap<UpdateStudentDto, Student>();
        }
    }
}
