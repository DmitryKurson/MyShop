namespace MyShop.Models
{
    public class Producer
    {
        public int id { get; set; }
        public string title { get; set; }
        public string country { get; set; }
        public string phone_number { get; set; }
        public List<Goods> goods { get; set; }
    }
}
