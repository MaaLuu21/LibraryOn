namespace LibraryOn.Domain.Exceptions.Errors;
public class DomainErrorCodes
{
    public const string InvalidPhoneNumber = "INVALID_PHONE_NUMBER";
    public const string InvalidEmail = "INVALID_EMAIL";
    public const string InvalidCpf = "INVALID_CPF";
    public const string LoanNotActive = "LOAN_IS_NOT_ACTIVE";
    public const string BookRequired = "BOOK_REQUIRED";
    public const string ReaderRequired = "READER_REQUIRED";
    public const string InvalidDueDate = "INVALID_DUE_DATE";
    public const string InvalidReturn = "RETURN_INVALID";
    public const string LimitLoans = "LIMIT_OF_LOANS_REACHED";
    public const string EmployeeRequired = "EMPLOYEE_REQUIRED";
}
