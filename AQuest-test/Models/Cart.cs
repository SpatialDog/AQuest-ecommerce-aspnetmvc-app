namespace AQuest_test.Models
{
    public class Cart
    {

        public string Id { get; set; }
        public List<Item> Items { get; set; }
        public float TotalCost => Items.Sum(item => item.Cost);  //calcolo del totale da pagare nel carrello

        public bool Discounted {  get; set; }

        public double Reduction { get; set; }
        public Cart()
        {
            Items = new List<Item>();
            Discounted = false;
        }

        public BillingInfo BillingInfo { get; set; }
    }
}
