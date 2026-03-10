namespace StudentManagement.MVC.Models
{
    public class StudentVm
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool Gender { get; set; }

        public DateTime? Dob { get; set; }

        public double Gpa { get; set; }

        public string DepartmentId { get; set; } = null!;

        public string DepartmentName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
