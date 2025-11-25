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
        string errorMessage = "";
        var userValidate = _userService.ValidateUser(model.Email, model.Password, ref errorMessage);
        if (!userValidate)
        {
            ViewBag.ErrorMessage = errorMessage;
            return View(model);
        }
        return RedirectToAction("Index", "Home");
    }
}