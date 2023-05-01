using System.Security.Claims;
using FixItApp.Infrastructure.DataTransferObjects;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixItApp.MVC.Controllers;

[Authorize]
[Controller]
[Route("[controller]")]
public class HomeController : Controller
{
    [HttpGet("Index")]
    public IActionResult Index()
    {
        var userPolicy = User.Claims.FirstOrDefault(c => c.Type == "Role");
        var userLogin = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        
        if (userPolicy.Value == "Manager")
            return View("ManagerHome", new UserDTO{Login = userLogin.Value});
        if (userPolicy.Value == "Master")
            return View("MasterHome");
        if (userPolicy.Value == "Customer")
            return View("CustomerHome", new UserDTO{Login = userLogin.Value});
        
        return View();
    }
    
    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("LogIn", "Access");
    }
    
}