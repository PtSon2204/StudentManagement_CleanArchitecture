using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Domain.Entities;

namespace StudentManagement.Application.DTOs.UserDtos
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }
    }
}
