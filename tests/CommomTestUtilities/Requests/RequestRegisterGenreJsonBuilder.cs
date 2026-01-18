using Bogus;
using LibraryOn.Communication.Requests.Genres;

namespace CommomTestUtilities.Requests;
public class RequestRegisterGenreJsonBuilder
{
    public static RequestGenreJson Build()
    {
        return new Faker<RequestGenreJson>()
            .RuleFor(g => g.Name, faker => faker.Person.FirstName);
    }
}
