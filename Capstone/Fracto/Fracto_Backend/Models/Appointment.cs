using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Appointment
{
    
    public int AppointmentId { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }
    [ForeignKey("Doctor")]
    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; }
    [Required]
    public DateTime AppointmentDate { get; set; }
    [Required]
    public string TimeSlot { get; set; } = string.Empty;
    [Required]
    public string Status { get; set; } = "Pending";
}
