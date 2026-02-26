using FluentValidation;
using LibraryOn.Communication.Requests.Loans;
using LibraryOn.Domain.ValueObjects;
using LibraryOn.Exception;

namespace LibraryOn.Application.UseCases.Loans.Register;
public class RegisterLoanValidator : AbstractValidator<RequestLoanJson>
{
    public RegisterLoanValidator()
    {
        RuleFor(l => l.Cpf).Must(Cpf.IsValidCpf)
        .When(l => !string.IsNullOrWhiteSpace(l.Cpf))
        .WithMessage(ResourceErrorMessages.CPF_INVALID);
        RuleFor(l => l.BookId).NotEmpty().WithMessage(ResourceErrorMessages.BOOK_ID_REQUIRED);
    }
}
