using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Application.Common;
using StudentManagement.Application.DTOs.UserDtos;
using StudentManagement.Domain.Queries;

namespace StudentManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<PagedResult<UserDto>> GetUsers(UserQuery query);
        Task<UserDto> GetByEmail(string? email);
        Task CreateUser(CreateUserDto dto);
        Task UpdateUser(string id, UpdateUserDto dto);
        Task DeleteUser(string email);
    }
}
