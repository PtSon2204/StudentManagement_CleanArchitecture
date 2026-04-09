namespace StudentManagement.MVC.Models.Students
{
    public class StudentQueryVm
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 6;
        public string? Name { get; set; }
        public bool? Gender { get; set; }
        public string? Department { get; set; }
    }
}
