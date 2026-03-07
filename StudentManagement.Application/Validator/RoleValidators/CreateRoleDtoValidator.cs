using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentManagement.Application.DTOs.RoleDtos;

namespace StudentManagement.Application.Validator.RoleValidators
{
    public class CreateRoleDtoValidator : AbstractValidator<CreateRoleDto>
    {
        public CreateRoleDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name không được để trống")
                .MaximumLength(100).WithMessage("Name tối đa 100 ký tự");
        }
    }
}
