using FluentValidation;
using LibraryOn.Application.SharedValidators;
using LibraryOn.Communication.Requests.Employees;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOn.Application.UseCases.Employee.ChangePassword;
public class ChangePasswordValidator : AbstractValidator<RequestChangePasswordJson>
{
    public ChangePasswordValidator()
    {
        RuleFor(e => e.NewPassword).SetValidator(new PasswordValidator<RequestChangePasswordJson>());
    }
}
