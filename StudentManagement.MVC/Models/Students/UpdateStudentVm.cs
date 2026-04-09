namespace StudentManagement.MVC.Models.Students
{
    public class UpdateStudentVm
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool Gender { get; set; }

        public DateTime? Dob { get; set; }

        public double Gpa { get; set; }

        public string DepartmentId { get; set; } = null!;
    }
}
