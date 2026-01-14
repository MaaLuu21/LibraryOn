using LibraryOn.Domain.Exceptions;

namespace LibraryOn.Domain.ValueObjects;
public sealed class Email
{
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidEmailException();
        }
        if (!value.Contains('@'))
        {
            throw new InvalidEmailException();
        }
        var parts = value.Split('@');

        if (parts.Length != 2 || string.IsNullOrWhiteSpace(parts[0]) || string.IsNullOrWhiteSpace(parts[1]))
        {
            throw new InvalidEmailException();
        }

        if (!parts[1].Contains('.'))
        {
            throw new InvalidEmailException();
        }

        return new Email(value.ToLowerInvariant());
    }

}
