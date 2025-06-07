using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd_ex4.Models;

[PrimaryKey(nameof(IdBook), nameof(IdAuthor))] // IdBook, not Book !!!
public class BookAuthor
{
    [ForeignKey(nameof(Book))] [Required]
    public int IdBook { get; set; }
    [ForeignKey(nameof(Author))] [Required]
    public int IdAuthor { get; set; }
    
    public Book Book { get; set; }
    public Author Author { get; set; }
}