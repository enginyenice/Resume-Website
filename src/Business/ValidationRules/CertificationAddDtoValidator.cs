using DTO.DTOs.CertificationDtos;
using FluentValidation;

namespace Business.ValidationRules
{
    public class CertificationAddDtoValidator : AbstractValidator<CertificationAddDto>
    {
        public CertificationAddDtoValidator()
        {
            RuleFor(p => p.Description).NotEmpty();
        }
    }
}