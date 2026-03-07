using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Domain.Interfaces;
using StudentManagement.Infrastructure.Data;

namespace StudentManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IStudentRepository StudentsRepo { get; }
    public IDepartmentRepository DepartmentRepo { get; }
    public IRoleRepository RoleRepo { get; }
    public IUserRepository UserRepo { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        StudentsRepo = new StudentRepository(_context);
        DepartmentRepo = new DepartmentRepository(_context);
        RoleRepo = new RoleRepository(_context);
        UserRepo = new UserRepository(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
}