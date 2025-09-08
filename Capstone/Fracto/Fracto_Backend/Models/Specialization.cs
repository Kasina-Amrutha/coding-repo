using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Specialization
{
    [Key]
    public int SpecializationId { get; set; }
    [Required]
    public string SpecializationName { get; set; } = string.Empty;

    public ICollection<Doctor>? Doctors { get; set; }
}
