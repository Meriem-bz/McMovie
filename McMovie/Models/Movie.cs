
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McMovie.Models;

public class Movie
{
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string? Title { get; set; }

    [Required]
    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [Required]
    [StringLength(30)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    public string? Genre { get; set; }

    [Range(0.01, 100)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [StringLength(5)]
    public string? Rating { get; set; }
}
