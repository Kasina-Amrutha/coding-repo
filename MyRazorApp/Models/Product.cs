using System.ComponentModel.DataAnnotations.Schema;

namespace MyRazorApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("category")]
        public int categID { get; set; }
        public Category category { get; set; }
    }
}
