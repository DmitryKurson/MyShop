namespace MyShop.Models
{
    public class Goods
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        //public string producer { get; set; }
        public int price { get; set; }

        public int ProdusersId { get; set; }
        public Producer Producer { get; set; }

        public List<Order> Orders { get; set; }
    }
}
