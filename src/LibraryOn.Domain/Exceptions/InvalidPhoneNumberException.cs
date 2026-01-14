using LibraryOn.Domain.Errors;

namespace LibraryOn.Domain.Exceptions;
public class InvalidPhoneNumberException : DomainException
{
    public InvalidPhoneNumberException() : base(DomainErrorCodes.InvalidPhoneNumber){ }
}
