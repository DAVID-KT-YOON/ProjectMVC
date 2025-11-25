using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRepository: BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(MovieShopDbContext context) : base(context)
    {
    }

    public IEnumerable<Movie> GetTop20GrossingMovies()
    {
        var movies = _context.Movies.OrderByDescending(m => m.Revenue).Take(20);
        return movies;
    }

    public Movie GetMovieWithGenresAndReview(int id)
    {
        return _context.Movies
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .Include(m => m.Reviews)
            .Include(m => m.Trailers)
            .Include(m => m.MovieCasts)
            .ThenInclude(mc => mc.Cast)
            .FirstOrDefault(m => m.Id == id);
    }
    public IEnumerable<Movie> GetMovieWithGenre(string genre)
    {
        return _context.Movies
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .Where(m => m.MovieGenres.Any(mg => mg.Genre.Name == genre)).Take(20)
            .ToList(); 
    }
}