using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieProjectMVC.Controllers;

public class AccountController:Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(LoginRequestModel model)
    {
        string errorMessage;
        var user = _userService.ValidateUser(model.Email, model.Password, out errorMessage);
        if (user == null)
        {
            Console.WriteLine("Invalid username or password");
            ViewBag.ErrorMessage = errorMessage;
            return View(model);
        }
        
        HttpContext.Session.SetInt32("UserId", user.Id);
        HttpContext.Session.SetString("UserEmail", user.Email);
        HttpContext.Session.SetString("UserName", $"{user.FirstName} {user.LastName}");
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}