using LibraryOn.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryOn.Infrastructure.DataAcess;
internal class LibraryOnDbContext : DbContext
{
    public LibraryOnDbContext(DbContextOptions options) : base(options) { } 

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<Genre>()
            .HasKey(g => g.Id);

        modelBuilder.Entity<Book>()
            .Property(b => b.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Genre>()
            .Property(g => g.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Book>()
            .HasMany(b => b.Genres)
            .WithMany(g => g.Books)
            .UsingEntity(j => j.ToTable("BookGenres"));
    }

}
