using AQuest_test.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;


namespace AQuest_test.Services
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor? _httpContextAccessor;
        private readonly ApplicationDbContext _context;
        private Cart _cart = new Cart();
        

        public CartService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _cart = GetCartFromSession();
        }
        public Cart GetCart()
        {
            return _cart;
        }
        public void AddItem(Product product, int quantity)
        {
            var item = _cart.Items.FirstOrDefault(i => i.Product.Id == product.Id);

            if (item == null)
            {
                item = new Item ( product, quantity );
                if(_cart.Discounted == true)
                {
                    item.Cost = (float)Math.Round(item.Cost * GetCartFromSession().Reduction,2);
                }
                _cart.Items.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }
            if (_cart.Discounted == true)
            {

            }
            UpdateCartInSession();
        }

        public void AddToCart(int productId, int quantity)
        {
            var product = _context.Product.Find(productId);

            if (product != null)
            {
                var newItem = new Item(product, quantity);
                if (_cart.Discounted == true)
                {
                    newItem.Cost = (float)Math.Round(newItem.Cost * GetCartFromSession().Reduction,2);


                }
                _cart.Items.Add(newItem);
            }
        }


        public void UpdateCart(Cart cart) //Salvo la rappresentazione dell'oggetto serializzato dentro cartJson in Session, quindi i dati persistono per tutta la sessione (anche quando si scorrono le pagine dell'app)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            _httpContextAccessor.HttpContext.Session.SetString("Cart", cartJson);//il Json lo salvo nella session, associato alla key Cart
            SaveCartToSession(_cart);
        }

        public void RemoveItem(int productId)
        {
            var cart = GetCart();
            var itemToRemove = cart.Items.FirstOrDefault(item => item.Product.Id == productId);

            if (itemToRemove != null)
            {
                cart.Items.Remove(itemToRemove);
                UpdateCartInSession();
            }
        }
        public void ClearCart()
        {
            _httpContextAccessor.HttpContext.Session.Remove("Cart");
        }

        private void UpdateCartInSession()
        {
            _httpContextAccessor.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(_cart));
        }

        private Cart GetCartFromSession() //Ritorna il Cart dalla sessione dell'utente, e nel caso non ce ne sia uno attivo ne crea uno nuovo
        {
            var cartJson = _httpContextAccessor.HttpContext.Session.GetString("Cart");

            if (!string.IsNullOrEmpty(cartJson))
            {
                return JsonConvert.DeserializeObject<Cart>(cartJson);
            }

            var cart = new Cart();
            _httpContextAccessor.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            return cart;
        }

        private void SaveCartToSession(Cart cart) //Salvo il cart nella sessione attiva
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            _httpContextAccessor.HttpContext.Session.SetString("Cart", cartJson);
        }

        public void TotalDiscounted(Coupon coupon)
        {
            Cart cart = GetCartFromSession();
            cart.Discounted = true;
            cart.Reduction = (1 - coupon.Percentage);
            float originalCost = 0;
            for (int i = 0; i < cart.Items.Count; i++)
            {
                originalCost = (float)Math.Round(cart.Items[i].Cost * cart.Reduction, 2);
                cart.Items[i].Cost = originalCost;
            }
            
            
            SaveCartToSession(cart);

        }

        public void AddBillingInfo(BillingInfo billingInfo)
        {
            Cart cart = GetCartFromSession();
            cart.BillingInfo = billingInfo;
            SaveCartToSession(cart);
        }

    }
}
