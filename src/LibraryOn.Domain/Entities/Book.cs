using System.Reflection.Metadata.Ecma335;

namespace LibraryOn.Domain.Entities;

public class Book
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    public int PublishYear { get; set; }
    public ICollection<Loan> Loans { get; set; } = [];
}
