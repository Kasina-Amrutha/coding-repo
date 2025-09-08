using System.ComponentModel.DataAnnotations;

namespace EcomApp.Models
{
    public class Product
    {
        [Key]
        public int product_id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public int stockQuality { get; set; }
    }
}
