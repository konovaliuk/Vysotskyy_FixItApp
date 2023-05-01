using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using FixItApp.ApplicationCore.Queries;
using FixItApp.MVC.Models;
using MediatR;

namespace FixItApp.MVC.Controllers;

public class AccessController : Controller
{
    private readonly IMediator _mediator;

    public AccessController(IMediator mediator) => _mediator = mediator;
    
    public IActionResult LogIn()
    {
        ClaimsPrincipal claimUser = HttpContext.User;
        if (claimUser.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Home");

        return View("~/Views/Home/LogIn.cshtml");
    }
    
    [HttpPost]
    public async Task<IActionResult> LogIn(UserLogin modelLogin)
    {
        var result = await _mediator.Send(new LogInUserQuery(modelLogin.Login, modelLogin.Password));
        
        if (result.Login != null) 
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, modelLogin.Login),
                new Claim("UserId", result.Id),
                new Claim("Role", result.Role)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = modelLogin.LoggedIn
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), properties);

            return RedirectToAction("Index", "Home");
        }
        
        return View("~/Views/Home/LogIn.cshtml");
    }
}