using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AQuest_test.Models;

namespace AQuest_test.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Terms_and_Conditions()
    {
        return View();
    }

    public IActionResult Success()
    {
        return View();
    }

    public IActionResult User_Info()
    {
        return View();
    } 

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
