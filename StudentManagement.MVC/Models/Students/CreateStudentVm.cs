namespace StudentManagement.MVC.Models.Students
{
    public class CreateStudentVm
    {

        public string Name { get; set; } = null!;

        public bool Gender { get; set; }

        public DateTime? Dob { get; set; }

        public double Gpa { get; set; }

        public string DepartmentId { get; set; } = null!;

    }
}
