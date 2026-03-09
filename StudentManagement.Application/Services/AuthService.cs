using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Application.DTOs.AuthDtos;
using StudentManagement.Application.Interfaces;
using StudentManagement.Domain.Interfaces;
using StudentManagement.Infrastructure.Identity;
using BCrypt.Net;
using StudentManagement.Domain.Entities;

namespace StudentManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtService _jwt;

        public AuthService(IUnitOfWork unitOfWork, JwtService jwt)
        {
            _unitOfWork = unitOfWork;
            _jwt = jwt;
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            //var user = await _unitOfWork.UserRepo.GetByEmail(dto.Email);

            //if (user == null)
            //{
            //    throw new Exception("User not found!");
            //}

            //bool valid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
            //if (!valid)
            //{
            //    throw new Exception("Password incorrect!");
            //}

            //return _jwt.GenerateToken(user);
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(RegisterDto dto)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = hash,
                RoleId = dto.RoleId,
            };

            //await _unitOfWork.UserRepo.CreateUser(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
