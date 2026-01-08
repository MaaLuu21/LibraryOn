using FluentValidation;
using LibraryOn.Communication.Requests.Books;
using LibraryOn.Exception;

namespace LibraryOn.Application.UseCases.Books;
public class BookValidator : AbstractValidator<RequestBookJson>
{
    public BookValidator()
    {
        RuleFor(book => book.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
        RuleFor(book => book.Author).NotEmpty().WithMessage(ResourceErrorMessages.AUTHOR_REQUIRED);
        RuleFor(book => book.PublishYear).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.PUBLISH_YEAR_CANT_BE_FOR_THE_FUTURE);
        RuleFor(book => book.GenreIds).NotEmpty().WithMessage(ResourceErrorMessages.GENRE_REQUIRED);
        RuleForEach(book => book.GenreIds).GreaterThan(0).WithMessage(ResourceErrorMessages.GENRE_REQUIRED);
    }
}
