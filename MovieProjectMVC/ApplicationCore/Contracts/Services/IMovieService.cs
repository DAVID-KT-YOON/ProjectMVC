using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IMovieService
{
    List<MovieCardModel> Top20GrossingMovie();
    MovieDetailsModel GetMovieDetails(int id);
    bool DeleteMovie(int id);
    List<MovieCardModel> ByGenre(string genre);
}