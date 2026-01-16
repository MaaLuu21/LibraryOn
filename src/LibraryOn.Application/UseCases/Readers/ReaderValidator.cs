using FluentValidation;
using LibraryOn.Communication.Requests.Readers;
using LibraryOn.Domain.Validators;
using LibraryOn.Domain.ValueObjects;
using LibraryOn.Exception;

namespace LibraryOn.Application.UseCases.Readers;
public class ReaderValidator : AbstractValidator<RequestReaderJson>
{
    public ReaderValidator(IPhoneNumberValidator phoneNumberValidator)
    {
        RuleFor(r => r.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_REQUIRED);
        RuleFor(r => r.PhoneNumber).NotEmpty().WithMessage(ResourceErrorMessages.PHONE_NUMBER_REQUIRED);
        RuleFor(r => r.Email).NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_REQUIRED)
            .Must(Email.IsValidEmail).WithMessage(ResourceErrorMessages.EMAIL_INVALID);
        RuleFor(r => r.Cpf).NotEmpty().WithMessage(ResourceErrorMessages.CPF_REQUIRED)
            .Must(Cpf.IsValidCpf).WithMessage(ResourceErrorMessages.CPF_INVALID);
        RuleFor(r => r.PhoneNumber).NotEmpty().WithMessage(ResourceErrorMessages.PHONE_NUMBER_REQUIRED)
            .Must(phoneNumberValidator.IsValid).WithMessage(ResourceErrorMessages.PHONE_NUMBER_INVALID);
    }

}
