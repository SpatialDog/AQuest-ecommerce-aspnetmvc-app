using AQuest_test.Models;
using AQuest_test.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AQuest_test.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CartService _cartService;

        public CartController(CartService cartService, ApplicationDbContext context)
        {
            _context = context;
            _cartService = cartService;
            
        }
        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }




        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartViewModel data)
        {
            if (ModelState.IsValid)
            {
                var cart = _cartService.GetCart();

                
                var existingItem = cart.Items.FirstOrDefault(item => item.Product.Id == data.ProductId);
                if (existingItem != null)
                {
                    
                    existingItem.Quantity = data.Quantity; //aggiorno la quantitá dell'oggetto se esiste giá
                    _cartService.UpdateCart(cart);

                    
                    return Json(new { updated = true });
                }

                // The product is not in the cart, add it
                _cartService.AddToCart(data.ProductId, data.Quantity);
                _cartService.UpdateCart(cart);

                // Return a JSON response with the updated flag set to false
                return Json(new { updated = false });
            }

            // Model validation failed, return a BadRequest response
            return BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> Remove(int ProductId)
        {
            _cartService.RemoveItem(ProductId);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Clear()
        {
            _cartService.ClearCart();
            return RedirectToAction("Index", "Cart");
        }
        [HttpPost]
        public IActionResult IsCouponValid( string code)
        {
            var data = _context.Coupon.FirstOrDefault(coupon => coupon.code == code);
            if (data != null && data.Used == false)
            {
                if (data.Expiration > DateTime.Now)
                {
                    _cartService.TotalDiscounted(data);

                    //inserire la logica per impostare Used a true nel record del DB con lo stesso codice
                    return Json(new { updated = true });
                }
                
            }
            
            return BadRequest();
        }
        [HttpPost]
        public IActionResult AddBillingInfo([FromBody] BillingInfo data)
        {
            if (data != null) { 
            
                if (data.FirstName != null && data.LastName != null && data.Email != null && data.Privacy != false) {
                    _cartService.AddBillingInfo(data);
                    return Json(new { updated = true });
                }
            }

            return BadRequest();
        }
    }
}
