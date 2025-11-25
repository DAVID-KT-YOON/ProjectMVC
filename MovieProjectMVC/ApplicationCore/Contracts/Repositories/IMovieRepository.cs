using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IMovieRepository: IRepository<Movie>
{
    IEnumerable<Movie> GetTop20GrossingMovies();
    Movie GetMovieWithGenresAndReview(int id);
    IEnumerable<Movie> GetMovieWithGenre(string genre);
}