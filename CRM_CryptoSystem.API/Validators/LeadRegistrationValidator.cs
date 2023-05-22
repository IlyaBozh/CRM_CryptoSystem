using CRM_CryptoSystem.API.Models.Requests;
using FluentValidation;

namespace CRM_CryptoSystem.API.Validators;

public class LeadRegistrationValidator : AbstractValidator<LeadRegistrationRequest>
{
    public LeadRegistrationValidator()
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
            .WithMessage("Maximum length is 23 symbols");

        RuleFor(v => v.Birthday)
            .NotEmpty()
            .WithMessage("Fill in the field")
            .LessThan(DateTime.Today)
            .WithMessage("Birthay must be less than today");

        RuleFor(v => v.Email)
            .NotEmpty()
            .WithMessage("Fill in the field")
            .EmailAddress()
            .WithMessage("Invalid email");

        RuleFor(v => v.Login)
            .NotEmpty()
            .WithMessage("Fill in the field")
            .MinimumLength(2)
            .WithMessage("Minimum length is 2 symbols")
            .MaximumLength(50)
            .WithMessage("Maximum length is 50 symbols");

        RuleFor(v => v.Password)
            .NotEmpty()
            .WithMessage("Fill in the field")
            .MinimumLength(8)
            .WithMessage("Minimum length is 8 symbols")
            .MaximumLength(30)
            .WithMessage("Maximum length is 30 symbols");
    }
}
