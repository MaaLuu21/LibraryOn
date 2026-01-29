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
        RuleFor(book => book.PublishYear).InclusiveBetween(1450, DateTime.UtcNow.Year)
                                         .WithMessage(ResourceErrorMessages.PUBLISH_YEAR_INVALID);
        RuleFor(book => book.GenreIds).NotEmpty().WithMessage(ResourceErrorMessages.GENRE_REQUIRED);
        RuleForEach(book => book.GenreIds).GreaterThan(0).WithMessage(ResourceErrorMessages.GENRE_REQUIRED);
    }

    private bool BeAValidPublishYear(DateTime publishYear)
    {
        var year = publishYear.Year;
        return year <= DateTime.UtcNow.Year && year >= 1450;
    }
}
