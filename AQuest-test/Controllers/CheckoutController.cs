using AQuest_test.Models;
using AQuest_test.Services;
using Microsoft.AspNetCore.Mvc;

namespace AQuest_test.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        private readonly CartService _cartService;
        public CheckoutController(ILogger<HomeController> logger, ApplicationDbContext context, CartService cartService)
        {
            _logger = logger;
            _context = context;
            _cartService = cartService;
        }

        

        public IActionResult Checkout()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }
    }
}
