using CommomTestUtilities.Requests;
using FluentAssertions;
using LibraryOn.Application.UseCases.Readers;
using LibraryOn.Domain.Validators;
using LibraryOn.Exception;
using Moq;

namespace Validators.Tests.Readers;
public class RegisterReaderValidatorTests
{
    [Fact]
    public void sucess()
    {
        //Arrange
        var phoneNumberValidatorMock = new Mock<IPhoneNumberValidator>();
        phoneNumberValidatorMock
            .Setup(p => p.IsValid(It.IsAny<string>()))
            .Returns(true);


        var validator = new ReaderValidator(phoneNumberValidatorMock.Object);
        var request = RequestRegisterReaderJsonBuilder.Build();

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeTrue();
    }
    [Theory]
    [InlineData("")]
    [InlineData("            ")]
    [InlineData(null)]
    public void Should_Return_Erro_When_Cpf_Is_Empty (string cpf)
    {
        var phoneNumberValidatorMock = new Mock<IPhoneNumberValidator>();
        phoneNumberValidatorMock
            .Setup(p => p.IsValid(It.IsAny<string>()))
            .Returns(true);

        var validator = new ReaderValidator(phoneNumberValidatorMock.Object);

        var request = RequestRegisterReaderJsonBuilder.Build();
        request.Cpf = cpf;

        
        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.CPF_REQUIRED));
    }

    [Theory]
    [InlineData("11111111111")]
    [InlineData("00000000000")]
    [InlineData("11122233345")]
    //[InlineData("123.456.789.09")]
    public void Should_Return_Erro_When_Cpf_Is_Not_Valid(string cpf)
    {
        var phoneNumberValidatorMock = new Mock<IPhoneNumberValidator>();
        phoneNumberValidatorMock
            .Setup(p => p.IsValid(It.IsAny<string>()))
            .Returns(true);

        var validator = new ReaderValidator (phoneNumberValidatorMock.Object);

        var request = RequestRegisterReaderJsonBuilder.Build();
        request.Cpf = cpf;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.CPF_INVALID));
    }

    [Theory]
    [InlineData("55169927901314")]
    public void Should_Return_Error_When_Phone_Is_Invalid(string phone)
    {
        var phoneNumberValidatorMock = new Mock<IPhoneNumberValidator>();
        phoneNumberValidatorMock
            .Setup(p => p.IsValid(phone))
            .Returns(false);

        var validator = new ReaderValidator(phoneNumberValidatorMock .Object);

        var request = RequestRegisterReaderJsonBuilder.Build();
        request.PhoneNumber = phone;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PHONE_NUMBER_INVALID));
    }
    [Theory]
    [InlineData("")]
    [InlineData("           ")]
    [InlineData(null)]
    public void Shoul_Return_Error_When_Phone_Is_Invalid(string phone)
    {
        var phoneNumberValidatorMock = new Mock<IPhoneNumberValidator>();
        phoneNumberValidatorMock
            .Setup(p => p.IsValid(phone))
            .Returns(false);

        var validator = new ReaderValidator(phoneNumberValidatorMock.Object);

        var request = RequestRegisterReaderJsonBuilder.Build();
        request.PhoneNumber = phone;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PHONE_NUMBER_REQUIRED));
    }

}