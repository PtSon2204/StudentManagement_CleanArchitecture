namespace StudentManagement.MVC.Models.Departments
{
    public class DepartmentQueryVm
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 6;
        public string? Name { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; } 
    }
}
