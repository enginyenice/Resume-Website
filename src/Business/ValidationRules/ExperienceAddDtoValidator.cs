using DTO.DTOs.ExperienceDtos;
using FluentValidation;

namespace Business.ValidationRules
{
    public class ExperienceAddDtoValidator : AbstractValidator<ExperienceAddDto>
    {
        public ExperienceAddDtoValidator()
        {
            RuleFor(p => p.Description).NotEmpty();

            RuleFor(p => p.StartDate).NotEmpty();
            RuleFor(p => p.SubTitle).NotEmpty();
            RuleFor(p => p.Title).NotEmpty();
        }
        
    }
}