using System.ComponentModel.DataAnnotations;
namespace MyShop.Models
{
    public class Client
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string adress { get; set; }
        public string phone_number { get; set; }
        public List<Order> orders { get; set; }
    }
}
