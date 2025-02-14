using MyShop.Models;

namespace MyShop.Models
{
    public class Product
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public int price { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public List<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
    }

}




   
