using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentsRepo { get; }
        IDepartmentRepository DepartmentRepo { get; }
        IRoleRepository RoleRepo { get; }
        IUserRepository UserRepo { get; }
        Task<int> SaveChangesAsync();
    }
}
