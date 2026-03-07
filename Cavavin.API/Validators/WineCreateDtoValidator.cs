namespace Cavavin.API.Validators;

using FluentValidation;
using Cavavin.API.DTOs;

public class WineCreateDtoValidator : AbstractValidator<WineCreateDto>
{
    public WineCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Le nom est obligatoire")
            .MaximumLength(100).WithMessage("Le nom est trop long");

        RuleFor(x => x.Domain)
            .NotEmpty().WithMessage("Le domaine est obligatoire");

        RuleFor(x => x.Vintage)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("Le millésime ne peut pas être dans le futur");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("La quantité doit être supérieure à 0");
    }
}