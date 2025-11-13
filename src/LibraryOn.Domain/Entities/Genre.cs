namespace LibraryOn.Domain.Entities;

public class Genre
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; } = new List<Book>();

}
