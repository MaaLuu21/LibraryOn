using LibraryOn.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryOn.Infrastructure.DataAcess;
internal class LibraryOnDbContext : DbContext
{
    public LibraryOnDbContext(DbContextOptions options) : base(options) { } 

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Reader> Readers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Genres)
            .WithMany(g => g.Books)
            .UsingEntity(j => j.ToTable("BookGenres"));


        modelBuilder.Entity<Reader>(entity =>
        {
            entity.HasKey(r => r.Id);

            entity.Property(r => r.Name)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.OwnsOne(r => r.PhoneNumber, pn =>
            {
                pn.Property(p => p.Value)
                  .HasColumnName("PhoneNumber")
                  .IsRequired();
            });

            entity.OwnsOne(r => r.Email, e =>
            {
                e.Property(p => p.Value)
                 .HasColumnName("Email")
                 .IsRequired();
            });

            entity.OwnsOne(r => r.Cpf, c =>
            {
                c.Property(p => p.Value)
                 .HasColumnName("Cpf")
                 .IsRequired();
            });
        });
    }

}
