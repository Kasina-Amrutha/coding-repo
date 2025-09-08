using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Models
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
        public class Customer
        {
            [Key]
            public int customer_id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string password { get; set; }
        }
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
}
