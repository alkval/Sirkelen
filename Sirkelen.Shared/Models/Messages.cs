using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace Sirkelen.Shared.Models;
public class Messages
{
    public Guid Id { get; set; }
    
    [Required]
    public User Sender { get; set; }

    [Required]
    public string Message { get; set; }

    [Required]
    public string Name { get; set; }
    public string? ProfilePicture { get; set; }
    public string? MediaUrl { get; set; }

    [Required]
    public DateTime Time { get; set; }
}