using FluentValidation;
using LibraryOn.Communication.Requests.Loans;
using LibraryOn.Domain.ValueObjects;
using LibraryOn.Exception;

namespace LibraryOn.Application.UseCases.Loans.Update;
public class UpdateLoanValidator : AbstractValidator<RequestLoanUpdateJson>
{
    public UpdateLoanValidator()
    {
        RuleFor(l => l.Cpf).Must(Cpf.IsValidCpf)
        .When(l => !string.IsNullOrWhiteSpace(l.Cpf))
        .WithMessage(ResourceErrorMessages.CPF_INVALID);
        RuleFor(l => l.ReturnedAt).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.RETURN_DATE_CAN_NOT_BE_IN_THE_FUTURE);
    }
}
