using LibraryOn.Domain.Errors;

namespace LibraryOn.Domain.Exceptions;
public class InvalidCpfException : DomainException
{
    public InvalidCpfException() : base(DomainErrorCodes.InvalidCpf){ }
}
