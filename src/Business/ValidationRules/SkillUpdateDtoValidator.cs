using DTO.DTOs.SkillDtos;
using FluentValidation;

namespace Business.ValidationRules
{
    public class SkillUpdateDtoValidator : AbstractValidator<SkillUpdateDto>
    {
        public SkillUpdateDtoValidator()
        {
            RuleFor(p => p.Id).InclusiveBetween(1, int.MaxValue);
            RuleFor(p => p.Description).NotEmpty();
        }
    }
}