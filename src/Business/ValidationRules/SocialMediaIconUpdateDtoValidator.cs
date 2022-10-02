using DTO.DTOs.SocialMediaIconDtos;
using FluentValidation;

namespace Business.ValidationRules
{
    public class SocialMediaIconUpdateDtoValidator : AbstractValidator<SocialMediaIconUpdateDto>
    {
        public SocialMediaIconUpdateDtoValidator()
        {
            RuleFor(p => p.Id).InclusiveBetween(1, int.MaxValue);
            RuleFor(p => p.Link).NotEmpty();
            RuleFor(p => p.Icon).NotEmpty();
        }
    }
}