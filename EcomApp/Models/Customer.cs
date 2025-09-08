using System.ComponentModel.DataAnnotations;

namespace EcomApp.Models
{
    public class Customer
    {
        [Key]
        public int customer_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
