using DTO.DTOs.SocialMediaIconDtos;
using FluentValidation;

namespace Business.ValidationRules
{
    public class SocialMediaIconAddDtoValidator : AbstractValidator<SocialMediaIconAddDto>
    {
        public SocialMediaIconAddDtoValidator()
        {
            RuleFor(p => p.Link).NotEmpty();
            RuleFor(p => p.Icon).NotEmpty();

        }
    }
}