using CRM_CryptoSystem.API.Models.Requests;
using FluentValidation;

namespace CRM_CryptoSystem.API.Validators;

public class LeadUpdateValidator : AbstractValidator<LeadUpdateRequest>
{
    public LeadUpdateValidator()
    {
        RuleFor(v => v.FirstName)
            .NotEmpty()
            .WithMessage("Fill in the field")
            .MinimumLength(2)
            .WithMessage("Minimum length is 2 symbols")
            .MaximumLength(50)
            .WithMessage("Maximum length is 50 symbols");

        RuleFor(v => v.LastName)
            .NotEmpty()
            .WithMessage("Fill in the field")
            .MinimumLength(2)
            .WithMessage("Minimum length is 2 symbols")
            .MaximumLength(50)
            .WithMessage("Maximum length is 50 symbols");

        RuleFor(v => v.Patronymic)
            .NotEmpty()
            .WithMessage("Fill in the field")
            .MinimumLength(2)
            .WithMessage("Minimum length is 2 symbols")
            .MaximumLength(50)
            .WithMessage("Maximum length is 50 symbols");

        RuleFor(v => v.Birthday)
            .NotEmpty()
            .WithMessage("Fill in the field")
            .LessThan(DateTime.Today)
            .WithMessage("Birthay must be less than today");
    }
}
