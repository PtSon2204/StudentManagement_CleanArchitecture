using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentManagement.Application.DTOs.DepartmentDtos;
using StudentManagement.Application.DTOs.RoleDtos;

namespace StudentManagement.Application.Validator.DepartmentValidators
{
    public class CreateDepartmentDtoValidator : AbstractValidator<CreateDepartmentDto>
    {
        public CreateDepartmentDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name không được để trống")
                .MaximumLength(100).WithMessage("Name tối đa 100 ký tự");
        }
    }
}
