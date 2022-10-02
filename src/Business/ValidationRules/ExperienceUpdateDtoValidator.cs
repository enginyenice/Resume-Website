using DTO.DTOs.ExperienceDtos;
using FluentValidation;

namespace Business.ValidationRules
{
    public class ExperienceUpdateDtoValidator : AbstractValidator<ExperienceUpdateDto>
    {
        public ExperienceUpdateDtoValidator()
        {
            RuleFor(p => p.Id).InclusiveBetween(1, int.MaxValue);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.StartDate).NotEmpty();
            RuleFor(p => p.SubTitle).NotEmpty();
            RuleFor(p => p.Title).NotEmpty();
        }
    }
}