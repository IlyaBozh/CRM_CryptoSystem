using CRM_CryptoSystem.API.Models.Requests;
using FluentValidation;

namespace CRM_CryptoSystem.API.Validators;

public class AddAccountValidator : AbstractValidator<AddAccountRequest>
{
    public AddAccountValidator()
    {
        RuleFor(a => a.CryptoCurrency)
            .IsInEnum()
            .NotEmpty();

        RuleFor(a => a.Status)
            .IsInEnum()
            .NotEmpty();

        RuleFor(a => a.LeadId)
            .NotNull()
            .NotEmpty();
    }
}
