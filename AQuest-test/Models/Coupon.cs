namespace AQuest_test.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string code { get; set; }

        public float Percentage { get; set; }

        public DateTime Expiration {  get; set; }

        public bool Used { get; set; }

    }
}
