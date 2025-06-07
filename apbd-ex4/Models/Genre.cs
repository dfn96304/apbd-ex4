﻿using System.ComponentModel.DataAnnotations;

namespace apbd_ex4.Models;

public class Genre
{
    [Key]
    public int IdGenre { get; set; }
    [MaxLength(50)] [Required]
    public string Name { get; set; }
}