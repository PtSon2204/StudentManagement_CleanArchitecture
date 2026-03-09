using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Application.Common;

namespace StudentManagement.Application.Queries
{
    public class StudentQuery : PaginationParams
    {
        public string? Name { get; set; }

        public bool? Gender { get; set; }

        public DateTime? Dob { get; set; }

        public double? Gpa { get; set; }

        public string? Department { get; set; }
    }
}
