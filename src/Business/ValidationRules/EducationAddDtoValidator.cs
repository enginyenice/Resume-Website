using DTO.DTOs.EducationDtos;
using FluentValidation;

namespace Business.ValidationRules
{
    public class EducationAddDtoValidator : AbstractValidator<EducationAddDto>
    {
        public EducationAddDtoValidator()
        {
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.StartDate).NotEmpty();
            RuleFor(p => p.SubTitle).NotEmpty();
            RuleFor(p => p.Title).NotEmpty();
        }   
    }
}