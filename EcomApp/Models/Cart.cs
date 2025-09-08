using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomApp.Models
{
    public class Cart
    {
        [Key]
        public int cart_id { get; set; }

        [ForeignKey("customer_id")]
        public int customer_id { get; set; }

        [ForeignKey("product_id")]
        public int product_id { get; set; }
        public int quality { get; set; }
    }
}
