using System.ComponentModel.DataAnnotations;
namespace MyShop.Models
{
    public class Clients
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string adress { get; set; }
        public string phone_number { get; set; }
        public List<Orders> orders { get; set; }
    }
}
