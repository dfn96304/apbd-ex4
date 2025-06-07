namespace apbd_ex4.DTOs;

using apbd_ex4.Models;

public class NewBookDTO
{
    public int PublishingHouseId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public ICollection<int> AuthorIds { get; set; }
    public int GenreId { get; set; }
}