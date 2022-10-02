using System;
using DTO.DTOs.AppUserDtos;
using FluentValidation;

namespace Business.ValidationRules
{
    public class AppUserForPasswordDtoValidator : AbstractValidator<AppUserForPasswordDto>
    {
        public AppUserForPasswordDtoValidator()
        {
            RuleFor(p => p.Id).InclusiveBetween(1, Int32.MaxValue);
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.ConfirmPassword).NotEmpty().Equal(p => p.Password);
        }
    }
}