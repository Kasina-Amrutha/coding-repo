using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Doctor
{
    [Key]
    public int DoctorId { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [ForeignKey("Specialization")]
    public int SpecializationId { get; set; }
    [Required]
    public string City { get; set; } = string.Empty;
    public double Rating { get; set; }
    public Specialization? Specialization { get; set; }

    public ICollection<Appointment>? Appointments { get; set; }
    public ICollection<Rating>? Ratings{ get; set; }
}
