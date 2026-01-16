using LibraryOn.Domain.Exceptions;
using LibraryOn.Domain.Exceptions.Errors;
using System.Text.RegularExpressions;

namespace LibraryOn.Domain.ValueObjects;
public record Cpf
{
    public string Value { get; }

    public Cpf(string value)
    {
        Value = value;
    }

    public static Cpf Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException(DomainErrorCodes.InvalidCpf);

        var cpf = new string(value.Where(char.IsDigit).ToArray());

        if (!IsValidCpf(cpf))
            throw new DomainException(DomainErrorCodes.InvalidCpf);

        return new Cpf(cpf);
    }

    public static bool IsValidCpf(string cpf)
    {
        var cpfClean = Regex.Replace(cpf, @"\D", "");

        if (cpfClean.Length != 11)
            return false;

        string[] invalids = {
            "00000000000", "11111111111", "22222222222", "33333333333",
            "44444444444", "55555555555", "66666666666", "77777777777",
            "88888888888", "99999999999"
        };

        if (invalids.Contains(cpfClean))
            return false;

        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += (cpfClean[i] - '0') * (10 - i);

        int remainder = sum % 11;
        int firstDigit = remainder < 2 ? 0 : 11 - remainder;

        if ((cpfClean[9] - '0') != firstDigit)
            return false;

        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += (cpfClean[i] - '0') * (11 - i);

        remainder = sum % 11;
        int secondDigit = remainder < 2 ? 0 : 11 - remainder;

        return (cpfClean[10] - '0') == secondDigit;
    }
    public override string ToString() => Value;
}
