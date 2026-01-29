using FluentValidation;
using LibraryOn.Application.SharedValidators;
using LibraryOn.Communication.Requests.Employee;
using LibraryOn.Domain.ValueObjects;
using LibraryOn.Exception;

namespace LibraryOn.Application.UseCases.Employee;
public class RegisterEmployeeValidator : AbstractValidator<RequestRegisterEmployeeJson>
{
    public RegisterEmployeeValidator()
    {
        RuleFor(e => e.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_REQUIRED);
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.EMAIL_REQUIRED)
            .EmailAddress()
            .When(user => !string.IsNullOrWhiteSpace(user.Email), ApplyConditionTo.CurrentValidator)
            .WithMessage(ResourceErrorMessages.EMAIL_INVALID);
        RuleFor(e => e.Password).SetValidator(new PasswordValidator<RequestRegisterEmployeeJson>());

    }
}
