using CommomTestUtilities.Requests;
using FluentAssertions;
using LibraryOn.Application.UseCases.Genres;
using LibraryOn.Exception;

namespace Validators.Tests.Genres.Register;
public class RegisterGenreValidatorTests
{
    [Fact]
    public void sucess()
    {
        //Arrange - parte de configurar as instancias
        var validator = new GenreValidator();
        var request = RequestRegisterGenreJsonBuilder.Build(); ;

        //Act - validar a ação
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeTrue();

    }

    [Theory]
    [InlineData("")]
    [InlineData("         ")]
    [InlineData(null)]
    public void Error_Name_empty(string name)
    {
        var validator = new GenreValidator();

        var request = RequestRegisterGenreJsonBuilder.Build();
        request.Name = name;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        //testar se contém somente um erro
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.GENRE_REQUIRED));

    }
}
