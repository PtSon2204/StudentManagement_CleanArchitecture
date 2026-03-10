using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudentManagement.Application.DTOs.UserDtos;
using StudentManagement.Domain.Entities;

namespace StudentManagement.Application.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleName,
                    opt => opt.MapFrom(src => src.Role.Name));

            CreateMap<CreateUserDto, User>();

            CreateMap<UpdateUserDto, User>();
        }
    }
}
