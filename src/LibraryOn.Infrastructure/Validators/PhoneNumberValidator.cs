using LibraryOn.Domain.Validators;
using PhoneNumbers;

namespace LibraryOn.Infrastructure.Validators;
public sealed class PhoneNumberValidator : IPhoneNumberValidator
{
    private readonly PhoneNumberUtil _phoneUtil;

    public PhoneNumberValidator()
    {
        _phoneUtil = PhoneNumberUtil.GetInstance();
    }

    public bool IsValid(string phoneNumber)
    {
        try
        {
            var number = _phoneUtil.Parse(phoneNumber, "BR");
            return _phoneUtil.IsValidNumber(number);
        }
        catch
        {
            return false;
        }
    }

}
