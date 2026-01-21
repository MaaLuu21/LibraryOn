using Bogus;
using LibraryOn.Communication.Requests.Genres;

namespace CommomTestUtilities.Requests;
public class RequestRegisterGenreJsonBuilder
{
    public static RequestGenreJson Build()
    {
        return new Faker<RequestGenreJson>()
            .RuleFor(g => g.Name, faker => faker.PickRandom(
                "Fantasy",
                "Science Fiction",
                "Romance",
                "Mystery",
                "Thriller",
                "Horror",
                "Adventure",
                "Action",
                "Drama",
                "Comedy",
                "Historical Fiction",
                "Biography",
                "Autobiography",
                "Memoir",
                "Non-Fiction",
                "Self-Help",
                "Personal Development"
                ));
    }
}
