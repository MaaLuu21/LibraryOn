using FluentValidation;
using FluentValidation.Validators;
using LibraryOn.Exception;
using System.Text.RegularExpressions;

namespace LibraryOn.Application.SharedValidators;
public class PasswordValidator<T> : PropertyValidator<T, string>
{
    private const string ERROR_MESSAGE_KEY = "ErrorMessage";

    public override string Name => "PasswordValidator";

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return $"{{{ERROR_MESSAGE_KEY}}}";
    }

    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrWhiteSpace(password)) return Invalid(context);
        if (password.Length < 8) return Invalid(context);
        if (!Regex.IsMatch(password, @"[A-Z]")) return Invalid(context);
        if (!Regex.IsMatch(password, @"[a-z]")) return Invalid(context);
        if (!Regex.IsMatch(password, @"[0-9]")) return Invalid(context);
        if (!Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]")) return Invalid(context);

        return true;
    }
    private static bool Invalid(ValidationContext<T> context)
    {
        context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
        return false;
    }
}
