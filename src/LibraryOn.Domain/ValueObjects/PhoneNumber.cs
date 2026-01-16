using LibraryOn.Domain.Exceptions;
using LibraryOn.Domain.Exceptions.Errors;
using LibraryOn.Domain.Validators;
using System.Text.RegularExpressions;

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
            throw new DomainException(DomainErrorCodes.InvalidPhoneNumber);
        }

        var phoneClean = Regex.Replace(value, @"\D", "");

        return new PhoneNumber(phoneClean);
    }
    public override string ToString() => Value;
}
