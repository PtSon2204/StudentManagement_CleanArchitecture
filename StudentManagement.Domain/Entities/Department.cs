using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Domain.Common;

namespace StudentManagement.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
