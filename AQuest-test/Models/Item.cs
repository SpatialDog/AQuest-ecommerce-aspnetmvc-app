namespace AQuest_test.Models
{
    public class Item //usiamo un model apposta per gli "oggetti" inseriti nel carrello, dove il costo viene calcolato in base al product.price e la quantity
    { 
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public float Cost
        {
            get;

            set;
        }

        public Item(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
            Cost = (float)Math.Round((Product.Price) * Quantity, 2);
        }
    }
}
