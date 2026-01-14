using LibraryOn.Domain.Exceptions;
using LibraryOn.Domain.Validators;

namespace LibraryOn.Domain.ValueObjects;
public sealed class PhoneNumber
{
    public string Value { get; }

    private PhoneNumber(string value)
    {
        Value = value;
    }

    public static PhoneNumber Create(string value, IPhoneNumberValidator validator)
    {
        if(string.IsNullOrEmpty(value) || !validator.IsValid(value))
        {
            throw new InvalidPhoneNumberException();
        }

        return new PhoneNumber(value);
    }

}
