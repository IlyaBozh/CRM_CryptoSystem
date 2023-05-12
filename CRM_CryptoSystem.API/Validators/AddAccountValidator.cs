using CRM_CryptoSystem.API.Models.Requests;
using FluentValidation;

namespace CRM_CryptoSystem.API.Validators;

public class AddAccountValidator : AbstractValidator<AddAccountRequest>
{
    public AddAccountValidator()
    {
        RuleFor(a => a.CryptoCurrencie)
            .IsInEnum()
            .NotEmpty();

        RuleFor(a => a.AccountStatus)
            .IsInEnum()
            .NotEmpty();

        RuleFor(a => a.LeadId)
            .NotNull()
            .NotEmpty();
    }
}
