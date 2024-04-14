using AQuest_test.Models;

namespace AQuest_test.Services
{
    public interface ICartService
    {
        void AddItem(Product product, int quantity);

        void RemoveItem(int productId);

        void ClearCart();

        Cart GetCart();

        void TotalDiscounted(Coupon coupon);
    }
}
