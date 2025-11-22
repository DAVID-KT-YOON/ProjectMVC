using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Cast
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string Name { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(2084)")]
    public string ProfilePath { get; set; }
    [Required]
    public string TmdbUrl { get; set; }
    
    public ICollection<MovieCast>? MovieCasts { get; set; }
}