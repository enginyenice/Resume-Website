using DTO.DTOs.AppUserDtos;
using FluentValidation;

namespace Business.ValidationRules
{
    public class AppUserUpdateDtoValidator : AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}