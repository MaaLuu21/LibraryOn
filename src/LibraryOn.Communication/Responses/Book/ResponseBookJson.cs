using LibraryOn.Communication.Responses.Genres;

namespace LibraryOn.Communication.Responses.Book
{
    public class ResponseBookJson
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<ResponseGenreJson> Genres { get; set; } = [];
        public DateTime PublishYear { get; set; }

    }
}
