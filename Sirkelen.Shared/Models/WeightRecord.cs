using System.ComponentModel.DataAnnotations;

public class WeightRecord
{
    public Guid Id { get; set; } // Primary key

    public User User { get; set; } // Navigation property

    public Guid UserId { get; set; } // Foreign key

    [Required]
    public decimal Weight { get; set; }

    [Required]
    public DateTime Date { get; set; }
}