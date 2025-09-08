using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    public string Role { get; set; } = "User";

    public ICollection<Appointment>? Appointments { get; set; }
    public ICollection<Rating>? Ratings { get; set; }
}
