using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace ShoppingPlatform.Models;
public class ApplicationUser : IdentityUser
{
    [Required]
        [StringLength(100)]
        public string? FullName { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [StringLength(100)]
        public string? City { get; set; }
}