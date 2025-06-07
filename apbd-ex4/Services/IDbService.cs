using apbd_ex4.DTOs;

namespace apbd_ex4.Services;

public interface IDbService
{
    public Task<List<GetBookDTO>> GetBooks(DateTime? releaseDate);
}