using CRM_CryptoSystem.API.Models.Requests;
using FluentValidation;

namespace CRM_CryptoSystem.API.Validators;

public class UpdateAccountValidator : AbstractValidator<UpdateAccountRequest>
{
    public UpdateAccountValidator()
    {
        RuleFor(a => a.AccountStatus)
            .IsInEnum()
            .NotEmpty();
    }
}
