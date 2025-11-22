using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Trailer
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(2084)")]
    public string Name { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(2084)")]
    public string TrailerUrl { get; set; }
}