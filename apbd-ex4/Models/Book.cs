using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_ex4.Models;

public class Book
{
    [Key]
    public int IdBook { get; set; }
    [MaxLength(50)] [Required]
    public string Name { get; set; }
    [Required]
    public DateTime ReleaseDate { get; set; }
    [ForeignKey(nameof(PublishingHouse))] [Required]
    public int IdPublishingHouse { get; set; }
    [ForeignKey(nameof(Genre))] [Required]
    public int IdGenre { get; set; }
    
    public PublishingHouse PublishingHouse { get; set; }
    
    public Genre Genre { get; set; }
}