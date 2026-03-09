using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Application.DTOs.StudentDtos
{
    public class UpdateStudentDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool Gender { get; set; }

        public DateTime? Dob { get; set; }

        public double Gpa { get; set; }

        public string DepartmentId { get; set; } = null!;

    }
}
