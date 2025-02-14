﻿namespace MyShop.Models
{
    public class Order
    {
        public int id { get; set; }
       
        public string status { get; set; }
        public int ClientId { get; set; }
        public Client client { get; set; }

        public List<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
    }
}
