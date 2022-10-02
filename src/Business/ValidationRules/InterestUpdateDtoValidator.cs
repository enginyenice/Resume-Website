using DTO.DTOs.InterestDtos;
using FluentValidation;

namespace Business.ValidationRules
{
    public class InterestUpdateDtoValidator : AbstractValidator<InterestUpdateDto>
    {
        public InterestUpdateDtoValidator()
        {
            RuleFor(p => p.Id).InclusiveBetween(1, int.MaxValue);
            RuleFor(p => p.Description).NotEmpty();
        }
    }
}