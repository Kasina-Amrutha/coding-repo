using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomApp.Models
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }
        [ForeignKey("customer_id")]
        public int customer_id { get; set; }
        public DateTime order_date { get; set; }
        public int total_price { get; set; }
        public string shopping_address { get; set; }
    }
}
