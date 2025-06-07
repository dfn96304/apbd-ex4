using apbd_ex4.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_ex4.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<PublishingHouse> PublishingHouses { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(new List<Author>
        {
            new Author(){ IdAuthor = 1, FirstName = "Milosz", LastName = "Salwowski"}
        });

        modelBuilder.Entity<Genre>().HasData(new List<Genre>
        {
            new Genre(){ IdGenre = 1, Name = "Fantasy"},
            new Genre(){ IdGenre = 2, Name = "Non-fiction"},
        });

        modelBuilder.Entity<PublishingHouse>().HasData(new List<PublishingHouse>
        {
            new PublishingHouse(){ IdPublishingHouse = 1, Name = "a", Country = "Poland", City = "Warsaw"},
            new PublishingHouse(){ IdPublishingHouse = 2, Name = "b", Country = "Poland", City = "Krakow"},
        });

        modelBuilder.Entity<Book>().HasData(new List<Book>
        {
            new Book(){ IdBook = 1, Name = "a", ReleaseDate = DateTime.Parse("2025-01-01"), IdPublishingHouse = 1, IdGenre = 1},
            new Book(){ IdBook = 2, Name = "b", ReleaseDate = DateTime.Parse("2025-01-03"), IdPublishingHouse = 2, IdGenre = 2},
        });

        modelBuilder.Entity<BookAuthor>().HasData(new List<BookAuthor>
        {
            new BookAuthor(){ IdBook = 1, IdAuthor = 1},
            new BookAuthor(){ IdBook = 2, IdAuthor = 1},
        });

    }
}