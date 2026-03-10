using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Application.Common;

namespace StudentManagement.Domain.Queries
{
    public class UserQuery : PaginationParams
    {
        public string? Email { get; set; }
    }
}
