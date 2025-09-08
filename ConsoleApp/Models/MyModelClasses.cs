using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    internal class MyModelClasses
    {
        public class Book
        {
            public int Id { get; set; }
            public string Type { get; set; }
            [ForeignKey("auth")]
            public int AuthorId { get; set; }
            public Author auth { get; set; }
            public string Description { get; set; }
        }
        public class Author
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
