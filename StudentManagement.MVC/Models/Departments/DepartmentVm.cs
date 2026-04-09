namespace StudentManagement.MVC.Models.Departments
{
    public class DepartmentVm
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
