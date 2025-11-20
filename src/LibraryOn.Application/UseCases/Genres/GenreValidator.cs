using FluentValidation;
using LibraryOn.Communication.Requests.Genres;
using LibraryOn.Exception;

namespace LibraryOn.Application.UseCases.Genres;
public class GenreValidator : AbstractValidator<RequestGenreJson>
{
    public GenreValidator()
    {
        RuleFor(genre => genre.Name).NotEmpty().WithMessage(ResourceErrorMessages.GENRE_REQUIRED);
    }
}
