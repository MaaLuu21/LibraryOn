using LibraryOn.Domain.Exceptions;
using LibraryOn.Domain.Exceptions.Errors;

namespace LibraryOn.Domain.ValueObjects;
public sealed class Email
{
    public string Value { get; }

    private Email(string value) => Value = value;

    public static bool IsValidEmail(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return false;
        if (!value.Contains('@')) return false;

        var parts = value.Split('@');
        if (parts.Length != 2 || string.IsNullOrWhiteSpace(parts[0]) || string.IsNullOrWhiteSpace(parts[1]))
            return false;

        if (!parts[1].Contains('.')) return false;

        return true;
    }

    public static Email Create(string value)
    {
        if (!IsValidEmail(value))
            throw new DomainException(DomainErrorCodes.InvalidEmail);

        return new Email(value.ToLowerInvariant());
    }
}

