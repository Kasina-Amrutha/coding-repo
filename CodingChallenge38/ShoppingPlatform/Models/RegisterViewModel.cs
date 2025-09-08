using System.ComponentModel.DataAnnotations;
namespace ShoppingPlatform.Models;
public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 8)]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$", ErrorMessage = "Password must include uppercase, number, and special character.")]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password")]
    public string? ConfirmPassword { get; set; }

    public string Role { get; set; } = "Customer";
}
