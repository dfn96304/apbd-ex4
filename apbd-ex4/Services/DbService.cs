using apbd_ex4.Data;
using apbd_ex4.DTOs;
using apbd_ex4.Models;

namespace apbd_ex4.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<GetBookDTO>> GetBooks(DateTime? releaseDate)
    {
        var books = _context.Books.Select(b => new GetBookDTO()
        {
            IdBook = b.IdBook,
            Name = b.Name,
            ReleaseDate = b.ReleaseDate,
            PublishingHouse = new GetBookPublishingHouseDTO()
            {
                IdPublishingHouse = b.PublishingHouse.IdPublishingHouse,
                Name = b.PublishingHouse.Name,
                City = b.PublishingHouse.City,
                Country = b.PublishingHouse.Country
            },
            Genre = new GetBookGenreDTO()
            {
                IdGenre = b.Genre.IdGenre,
                Name = b.Genre.Name,
            }
        }).ToList();
        
        return books;
    }

    public async Task<Book> NewBook(NewBookDTO book)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var publishingHouse =
                    _context.PublishingHouses.FirstOrDefault(ph => ph.IdPublishingHouse == book.PublishingHouseId);
                if (publishingHouse == null)
                {
                    var entity = _context.PublishingHouses.Add(new PublishingHouse()
                    {
                        //IdPublishingHouse = book.PublishingHouseId,
                        Country = book.Country,
                        City = book.City,
                        Name = book.Name,
                    });
                    
                    publishingHouse = entity.Entity;
                }

                foreach (var authorId in book.AuthorIds)
                {
                    var author = _context.Authors.FirstOrDefault(a => a.IdAuthor == authorId);
                    if (author == null)
                    {
                        throw new BadHttpRequestException("Author ID "+authorId+" not found");
                    }
                }
                
                var genre = _context.Genres.FirstOrDefault(g => g.IdGenre == book.GenreId);
                if (genre == null)
                {
                    throw new BadHttpRequestException("Genre ID "+book.GenreId+" not found");
                }

                var bookEntry = _context.Books.Add(new Book()
                {
                    Name = book.Name,
                    ReleaseDate = DateTime.Now,
                    IdPublishingHouse = book.PublishingHouseId,
                    IdGenre = book.GenreId,
                    PublishingHouse = publishingHouse,
                    Genre = genre,
                });

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return bookEntry.Entity;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}