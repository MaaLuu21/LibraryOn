using LibraryOn.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryOn.Infrastructure.DataAcess;
internal class LibraryOnDbContext : DbContext
{
    public LibraryOnDbContext(DbContextOptions options) : base(options) { } 

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }

}
