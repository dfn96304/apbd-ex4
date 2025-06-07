using apbd_ex4.DTOs;
using apbd_ex4.Models;

namespace apbd_ex4.Services;

public interface IDbService
{
    public Task<List<GetBookDTO>> GetBooks(DateTime? releaseDate);
    public Task<Book> NewBook(NewBookDTO book);
}