using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomApp.Models
{
    public class OrderItem
    {
        [Key]
        public int order_item_id { get; set; }
        [ForeignKey("order_id")]
        public int order_id { get; set; }
        [ForeignKey("product_id")]
        public int product_id { get; set; }
        public int quantity { get; set; }
    }
}
