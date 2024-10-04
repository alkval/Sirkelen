using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace Sirkelen.Shared.Models;
public class PersonalRecord
{
    public Guid Id { get; set; } // Primary key

    public Guid UserId { get; set; } // Foreign key
    public User User { get; set; } // Navigation property

    [Required]
    public string ExerciseName { get; set; }

    [Required]
    public decimal Weight { get; set; }

    [Required]
    public int Reps { get; set; }

    [Required]
    public int Sets { get; set; }

    [Required]
    public DateTime Date { get; set; }
}