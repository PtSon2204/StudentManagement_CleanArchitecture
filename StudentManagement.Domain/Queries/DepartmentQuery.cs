using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Application.Common;

namespace StudentManagement.Domain.Queries
{
    public class DepartmentQuery : PaginationParams
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string? Name { get; set; }
    }
}
