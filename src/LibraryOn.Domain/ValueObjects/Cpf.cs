using LibraryOn.Domain.Exceptions;

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
        if(string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidCpfException();
        }

        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidCpfException();

        // Remove tudo que não é número
        var cpf = new string(value.Where(char.IsDigit).ToArray());

        // Validação completa
        if (!IsValidCpf(cpf))
            throw new InvalidCpfException();

        return new Cpf(cpf);
    }

    private static bool IsValidCpf(string cpf)
    {
        if (cpf.Length != 11)
            return false;

        string[] invalids = {
            "00000000000", "11111111111", "22222222222", "33333333333",
            "44444444444", "55555555555", "66666666666", "77777777777",
            "88888888888", "99999999999"
        };

        if (invalids.Contains(cpf))
            return false;

        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += (cpf[i] - '0') * (10 - i);

        int remainder = sum % 11;
        int firstDigit = remainder < 2 ? 0 : 11 - remainder;

        if ((cpf[9] - '0') != firstDigit)
            return false;

        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += (cpf[i] - '0') * (11 - i);

        remainder = sum % 11;
        int secondDigit = remainder < 2 ? 0 : 11 - remainder;

        return (cpf[10] - '0') == secondDigit;
    }
}
