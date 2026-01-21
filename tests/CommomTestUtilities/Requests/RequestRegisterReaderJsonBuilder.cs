using Bogus;
using Bogus.Extensions.Brazil;
using LibraryOn.Communication.Requests.Readers;

namespace CommomTestUtilities.Requests;
public class RequestRegisterReaderJsonBuilder
{
    public static RequestReaderJson Build()
    {
        return new Faker<RequestReaderJson>()
                .RuleFor(r => r.Cpf, faker => faker.Person.Cpf())
                .RuleFor(r => r.Email, faker => faker.Person.Email)
                .RuleFor(r => r.Name, faker => faker.Person.FullName)
                .RuleFor(r => r.PhoneNumber, faker =>
                {
                    var ddd = faker.PickRandom("11", "16", "21", "18");
                    var number = faker.Random.ReplaceNumbers("9####-####");
                    return $"+55{ddd}{number.Replace("-", "")}";
                });
    }


}
