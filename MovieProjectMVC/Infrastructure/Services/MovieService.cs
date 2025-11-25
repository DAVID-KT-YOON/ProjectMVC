using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class MovieService: IMovieService
{
    private readonly IMovieRepository _repository;
    public MovieService(IMovieRepository movieRepository)
    {
        _repository = movieRepository;
    }
    public List<MovieCardModel> Top20GrossingMovie()
    {
        var movies = _repository.GetTop20GrossingMovies();
        var movieCardModels = new List<MovieCardModel>();
        foreach (var movie in movies)
        {
            movieCardModels.Add(new MovieCardModel()
            {
                Title = movie.Title,
                Id = movie.Id,
                PosterUrl = movie.PosterUrl
            });
        }
        return movieCardModels;
    }

    public List<MovieCardModel> ByGenre(string genre)
    {
        var movies = _repository.GetMovieWithGenre(genre);
        var movieCardModels = new List<MovieCardModel>();
        foreach (var movie in movies)
        {
            movieCardModels.Add(new MovieCardModel()
            {
                Title = movie.Title,
                Id = movie.Id,
                PosterUrl = movie.PosterUrl
            });
        }
        return movieCardModels;
    }

    public MovieDetailsModel GetMovieDetails(int id)
    {
        var movie = _repository.GetMovieWithGenresAndReview(id);
        if (movie == null)
        {
            return null;
        }

        var movieDetailsModel = new MovieDetailsModel()
        {
            Id = movie.Id,
            Title = movie.Title,
            PosterUrl = movie.PosterUrl,
            Overview = movie.Overview,
            Reviews = movie.Reviews?.ToList(),
            Genres= movie.MovieGenres?.Select(mg => mg.Genre).ToList(),
            Price = movie.Price,
            Trailers = movie.Trailers?.ToList(),
            Casts    = movie.MovieCasts?.Select(mc => mc.Cast).ToList(),
            OriginalLanguage= movie.OriginalLanguage,
            ReleaseDate= movie.ReleaseDate,
            Revenue = movie.Revenue
        };
        return movieDetailsModel;
    }

    public bool DeleteMovie(int id)
    {
        var movie = _repository.DeleteById(id);
        if (movie == null)
        {
            return false;
        }

        return true;
    }
}
