using FluentValidation;
using LibraryOn.Communication.Requests.Loans;
using LibraryOn.Domain.ValueObjects;
using LibraryOn.Exception;

namespace LibraryOn.Application.UseCases.Loans;
public class LoanValidator : AbstractValidator<RequestLoanJson>
{
    public LoanValidator()
    {
        RuleFor(loan => loan.Cpf).Must(Cpf.IsValidCpf)
        .When(r => !string.IsNullOrWhiteSpace(r.Cpf))
        .WithMessage(ResourceErrorMessages.CPF_INVALID);
        RuleFor(loan => loan.BookId).NotEmpty().WithMessage(ResourceErrorMessages.BOOK_ID_REQUIRED);
    }
}
