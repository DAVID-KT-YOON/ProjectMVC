using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieProjectMVC.Controllers;

public class MoviesController:Controller
{
    private readonly IMovieService  _movieService;
    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
        
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult MovieDetails(int id)
    {
        var movie = _movieService.GetMovieDetails(id);
        return View(movie);
    }

    [HttpPost]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _movieService.GetMovieDetails(id);
        if (movie == null)
        {
            return NotFound();
        }
        _movieService.DeleteMovie(id);
        return RedirectToAction("Index","Home");
    }

    public IActionResult ByGenre(string genre)
    {
        var movies = _movieService.ByGenre(genre);
        return View("~/Views/Home/Index.cshtml",movies);
    }
}