using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Application.Common;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.Queries;

namespace StudentManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<PagedResult<User>> GetUsers(UserQuery query);
        Task<User?> GetById(Guid id);
        Task<User?> GetUserByEmail(string email);
        Task CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
