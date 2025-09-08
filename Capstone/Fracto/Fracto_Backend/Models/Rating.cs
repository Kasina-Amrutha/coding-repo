using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Rating
{
    [Key]
    public int RatingId { get; set; }
    [ForeignKey("Doctor")]
    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }
    public int Score { get; set; }
}
