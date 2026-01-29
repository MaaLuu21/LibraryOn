using CommomTestUtilities.Requests;
using FluentAssertions;
using LibraryOn.Application.UseCases.Books;
using LibraryOn.Exception;

namespace Validators.Tests.Books;
public class RegisterBookValidatorTest
{
    [Fact]
    public void Succes()
    {
        var validate = new BookValidator();

        var request = RequestRegisterBookJsonBuilder.Build();
        var result = validate.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void Shoul_Return_Error_When_Title_Empty(string title)
    {
        var validate = new BookValidator();

        var request = RequestRegisterBookJsonBuilder.Build();
        request.Title = title;

        var result = validate.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void Shoul_Return_Error_When_Author_Empty(string author)
    {
        var validate = new BookValidator();

        var request = RequestRegisterBookJsonBuilder.Build();
        request.Author = author;

        var result = validate.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.AUTHOR_REQUIRED));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(12)]
    [InlineData(123)]
    [InlineData(1234)]
    [InlineData(12345)]
    [InlineData(null)]
    public void Shoul_Return_Error_When_PublishYear_Invalid(int publishYear)
    {
        var validate = new BookValidator();

        var request = RequestRegisterBookJsonBuilder.Build();
        request.PublishYear = publishYear;

        var result = validate.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PUBLISH_YEAR_INVALID));
    }

    [Theory]
    [MemberData(nameof(GenresIdEmpty))]
    [InlineData(null)]
    public void Shoul_Return_Error_When_GenresId_Empty(List<long> genresId)
    {
        var validate = new BookValidator();

        var request = RequestRegisterBookJsonBuilder.Build();
        request.GenreIds = genresId;

        var result = validate.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.GENRE_REQUIRED));
    }

    [Theory]
    [InlineData(new long[] { 0 })]
    public void Shoul_Return_Error_When_GenresId_Invalid(long [] genresId)
    {
        var validate = new BookValidator();

        var request = RequestRegisterBookJsonBuilder.Build();
        request.GenreIds = genresId.ToList();

        var result = validate.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.GENRE_REQUIRED));
    }


    public static IEnumerable<object[]> GenresIdEmpty()
    {
        yield return new object[] { new List<long>() };
    }


}

