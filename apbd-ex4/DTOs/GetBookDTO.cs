using apbd_ex4.Models;

namespace apbd_ex4.DTOs;

public class GetBookDTO
{
    public int IdBook { get; set; }
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public GetBookPublishingHouseDTO PublishingHouse { get; set; }
    public GetBookGenreDTO Genre { get; set; }
}

public class GetBookPublishingHouseDTO
{
    public int IdPublishingHouse { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}

public class GetBookGenreDTO
{
    public int IdGenre { get; set; }
    public string Name { get; set; }
}