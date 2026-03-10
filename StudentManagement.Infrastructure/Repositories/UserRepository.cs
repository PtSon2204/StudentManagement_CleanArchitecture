    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Application.Common;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.Interfaces;
using StudentManagement.Domain.Queries;
using StudentManagement.Infrastructure.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StudentManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateUser(User user)
        {
            await context.AddAsync(user);
        }

        public void DeleteUser(User user)
        {
             context.Remove(user);
        }

        public async Task<User?> GetById(Guid id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<PagedResult<User>> GetUsers(UserQuery query)
        {
            var users = context.Users.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(query.Email))
            {
                users = users.Where(x => x.Email == query.Email);
            }

            var totalRecords = await users.CountAsync();
            var data = await users
            .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

            return new PagedResult<User>
            {
                Data = data,
                PageNumber = query.PageNumber,
                PageSize = query.PageSize,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)query.PageSize)
            };
        }

        public void UpdateUser(User user)
        {
            context.Update(user);
        }
    }
}
