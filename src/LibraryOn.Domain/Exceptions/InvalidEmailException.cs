using LibraryOn.Domain.Errors;

namespace LibraryOn.Domain.Exceptions;
public class InvalidEmailException : DomainException
{
    public InvalidEmailException() : base(DomainErrorCodes.InvalidEmail) { }
}
