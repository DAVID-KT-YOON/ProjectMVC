using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Genre
{   [Required]
    public string Name { get; set; }
    [Key]
    public int Id { get; set; }
    public ICollection<MovieGenre>? MovieGenres { get; set; }
}