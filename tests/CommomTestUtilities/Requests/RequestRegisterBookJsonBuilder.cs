using Bogus;
using LibraryOn.Communication.Requests.Books;

namespace CommomTestUtilities.Requests;
public class RequestRegisterBookJsonBuilder
{
    public static RequestBookJson Build()
    {
        return new Faker<RequestBookJson>()
            .RuleFor(b => b.Author, faker => faker.Person.FullName)
            .RuleFor(b => b.Description, faker => faker.Lorem.Sentence(10, 10))
            .RuleFor(b => b.Title, faker => faker.Lorem.Word())
            .RuleFor(b => b.PublishYear, _ => 2026)
            .RuleFor(b => b.GenreIds, _ => new List<long> { 1, 2, 3});
    }
}
