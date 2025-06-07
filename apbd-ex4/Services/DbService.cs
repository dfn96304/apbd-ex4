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
}