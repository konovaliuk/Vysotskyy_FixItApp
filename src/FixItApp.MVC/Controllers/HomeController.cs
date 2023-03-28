using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FixItApp.MVC.Models;

namespace FixItApp.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return  View();
    }
}