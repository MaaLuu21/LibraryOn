using LibraryOn.Application.Services;
using LibraryOn.Domain.Validators;
using PhoneNumbers;

namespace LibraryOn.Infrastructure.Validators;
public sealed class PhoneNumberValidator : IPhoneNumberValidator
{
    private readonly PhoneNumberUtil _phoneUtil;
    private readonly IRegionProvider _regionProvider;

    public PhoneNumberValidator(IRegionProvider regionProvider)
    {
        _phoneUtil = PhoneNumberUtil.GetInstance();
        _regionProvider = regionProvider;
    }

    public bool IsValid(string phoneNumber)
    {
        try
        {
            var regionCode = _regionProvider.GetRegionCode();
            var number = _phoneUtil.Parse(phoneNumber, regionCode);
            return _phoneUtil.IsValidNumber(number);
        }
        catch
        {
            return false;
        }
    }

}
