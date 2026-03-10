using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudentManagement.Application.Common;
using StudentManagement.Application.DTOs.StudentDtos;
using StudentManagement.Application.DTOs.UserDtos;
using StudentManagement.Application.Interfaces;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.Interfaces;
using StudentManagement.Domain.Queries;

namespace StudentManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateUser(CreateUserDto dto)
        {
            var existingUser = await _unitOfWork.UserRepo.GetUserByEmail(dto.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var newUser = _mapper.Map<User>(dto);

            await _unitOfWork.UserRepo.CreateUser(newUser);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUser(string email)
        {
            var user = await _unitOfWork.UserRepo.GetUserByEmail(email);
            _unitOfWork.UserRepo.DeleteUser(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserDto> GetByEmail(string? email)
        {
            var user = await _unitOfWork.UserRepo.GetUserByEmail(email);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<PagedResult<UserDto>> GetUsers(UserQuery query)
        {
            var result = await _unitOfWork.UserRepo.GetUsers(query);

            return new PagedResult<UserDto>
            {
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                TotalRecords = result.TotalRecords,
                TotalPages = result.TotalPages,

                Data = _mapper.Map<IEnumerable<UserDto>>(result.Data)
            };
        }

        public async Task UpdateUser(string id, UpdateUserDto dto)
        {
            var guid = Guid.Parse(id);

            var user = await _unitOfWork.UserRepo.GetById(guid);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.Email = dto.Email;
            user.RoleId = dto.RoleId;

            _unitOfWork.UserRepo.UpdateUser(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
