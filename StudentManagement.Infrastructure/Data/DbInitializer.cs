using StudentManagement.Domain.Entities;

namespace StudentManagement.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            SeedRoles(context);
            SeedUsers(context);
            SeedDepartments(context);
            SeedStudents(context);
        }

        private static void SeedRoles(ApplicationDbContext context)
        {
            if (context.Roles.Any()) return;

            context.Roles.AddRange(
                new Role { Name = "Admin", CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Role { Name = "User", CreatedAt = DateTime.UtcNow, IsDeleted = false }
            );

            context.SaveChanges();
        }

        private static void SeedUsers(ApplicationDbContext context)
        {
            if (context.Users.Any()) return;

            var adminRole = context.Roles.First(r => r.Name == "Admin");

            context.Users.Add(new User
            {
                Email = "admin@gmail.com",
                PasswordHash = "123456",
                RoleId = adminRole.Id,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            });

            context.SaveChanges();
        }

        private static void SeedDepartments(ApplicationDbContext context)
        {
            if (context.Departments.Any()) return;

            context.Departments.AddRange(
                new Department { Id = "AI", Name = "Trí tuệ nhân tạo", CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Department { Id = "BA", Name = "Quản trị kinh doanh", CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Department { Id = "En", Name = "Ngôn Ngữ Anh", CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Department { Id = "GD", Name = "Thiết kế đồ họa", CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Department { Id = "IA", Name = "An Toàn thông tin", CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Department { Id = "JP", Name = "Ngôn ngữ Nhật", CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Department { Id = "SE", Name = "Kỹ thuật phần mềm", CreatedAt = DateTime.UtcNow, IsDeleted = false }
            );

            context.SaveChanges();
        }

        private static void SeedStudents(ApplicationDbContext context)
        {
            if (context.Students.Any()) return;

            context.Students.AddRange(
                new Student {  Name = "Trần B124", Gender = false, DepartmentId = "En", Dob = new DateTime(2001, 2, 16), Gpa = 6.7, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Student { Name = "Trần C", Gender = true, DepartmentId = "IA", Dob = new DateTime(2001, 3, 28), Gpa = 6, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Student { Name = "TChu DE123", Gender = true, DepartmentId = "En", Dob = new DateTime(2023, 6, 2), Gpa = 3, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Student {  Name = "ABc123", Gender = false, DepartmentId = "IA", Dob = new DateTime(2023, 6, 2), Gpa = 3, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Student {  Name = "Nóng như lửa", Gender = false, DepartmentId = "SE", Dob = new DateTime(2001, 2, 28), Gpa = 6, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Student { Name = "Lạnh Như Băng", Gender = true, DepartmentId = "AI", Dob = new DateTime(2001, 4, 25), Gpa = 8, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Student { Name = "TChu DE", Gender = true, DepartmentId = "AI", Dob = new DateTime(2023, 6, 2), Gpa = 3, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Student { Name = "TChu DE", Gender = false, DepartmentId = "SE", Dob = new DateTime(2000, 6, 13), Gpa = 3, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Student { Name = "Nguyen Van ko Co", Gender = true, DepartmentId = "IA", Dob = new DateTime(2000, 6, 30), Gpa = 8, CreatedAt = DateTime.UtcNow, IsDeleted = false }
            );

            context.SaveChanges();
        }
    }
}