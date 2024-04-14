using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AQuest_test.Models;
using Microsoft.EntityFrameworkCore;
using AQuest_test.Services;

namespace AQuest_test.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly CartService _cartService;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, CartService cartService)
    {
        _logger = logger;
        _context = context;
        _cartService = cartService;
    }

    public async Task<IActionResult> Index()//Mostro i prodotti del DB sulla pagina
    {
        var data = await _context.Product.ToListAsync();
        
        return _context.Product != null ? View(data) : Problem("ApplicationDdContext.Products is null");
        
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

    public IActionResult User_info()
    {
        Cart cart = _cartService.GetCart();
        if (cart.Items.Count != 0)
        {
            return View();
        }
        return RedirectToAction("index");


    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }




}
