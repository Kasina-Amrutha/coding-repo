using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required]
        public string? Title { get; set; }
        
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        
        public ICollection<BookGenre>? BookGenres { get; set; }
    }
}
