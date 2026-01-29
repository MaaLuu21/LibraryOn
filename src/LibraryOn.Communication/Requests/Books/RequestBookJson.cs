namespace LibraryOn.Communication.Requests.Books;
public class RequestBookJson
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string? Description { get; set; }
    public List<long> GenreIds { get; set; } = [];
    public int PublishYear { get; set; }
}
