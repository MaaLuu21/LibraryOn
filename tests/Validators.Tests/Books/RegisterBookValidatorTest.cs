using CommomTestUtilities.Requests;
using FluentAssertions;
using LibraryOn.Application.UseCases.Books;

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
}
