using System.ComponentModel.DataAnnotations;

public class User
{
    public Guid Id { get; set; } // Primary key

    public int? Rank { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public decimal? Height { get; set; }

    public decimal? Weight { get; set; }

    [Required]
    public DateTime JoinDate { get; set; }

    public DateTime? LastLogin { get; set; }

    public List<PersonalRecord> PersonalRecords { get; set; } = new List<PersonalRecord>();
    public List<WeightRecord> WeightRecords { get; set; } = new List<WeightRecord>();

    [Required]
    public bool IsAdmin { get; set; } = false;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public User()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        Weight = WeightRecords.LastOrDefault()?.Weight;
    }
}