using DTO.DTOs.InterestDtos;
using FluentValidation;

namespace Business.ValidationRules
{
    public class InterestAddDtoValidator : AbstractValidator<InterestAddDto>
    {
        public InterestAddDtoValidator()
        {
            RuleFor(p => p.Description).NotEmpty();
        }
    }
}