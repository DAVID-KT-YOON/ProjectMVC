using ApplicationCore.Entities;

namespace ApplicationCore.Models;

public class MovieDetailsModel
{
    public int  Id { get; set; }
    public string Title { get; set; }
    public string PosterUrl { get; set; }
    public ICollection<Genre> Genres { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Trailer> Trailers { get; set; }
    public ICollection<Cast> Casts { get; set; }
    public string? Overview { get; set; }
    public decimal? Price { get; set; }
    public string OriginalLanguage { get; set; }
    public decimal? Revenue { get; set; }
    public DateTime? ReleaseDate { get; set; }
}