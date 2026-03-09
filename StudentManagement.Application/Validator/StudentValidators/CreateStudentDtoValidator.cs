using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StudentManagement.Application.DTOs.RoleDtos;
using StudentManagement.Application.DTOs.StudentDtos;

namespace StudentManagement.Application.Validator.StudentValidators
{
    public class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
    {
        public CreateStudentDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name không được để trống")
            .MaximumLength(100).WithMessage("Name tối đa 100 ký tự");

            RuleFor(x => x.Gpa)
                .InclusiveBetween(0, 10)
                .WithMessage("GPA phải từ 0 đến 10");

            RuleFor(x => x.DepartmentId)
                .NotEmpty()
                .WithMessage("DepartmentId không được để trống");

            RuleFor(x => x.Dob)
                .LessThan(DateTime.Now)
                .WithMessage("Ngày sinh phải nhỏ hơn ngày hiện tại");
        }
    }
}
