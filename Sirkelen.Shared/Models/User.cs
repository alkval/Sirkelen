using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

namespace Sirkelen.Shared.Models;
[Collection("Users")]
public class User
{
    public ObjectId Id { get; set; }

    [Display(Name = "Rank")]
    public int? Rank { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Username is required")]
    [Display(Name = "Username")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? PasswordHash { get; set; }

    public string? ProfilePictureUrl { get; set; }

    [Display(Name = "Height")]
    public decimal? Height { get; set; }

    [Display(Name = "Weight")]
    public decimal? Weight { get; set; }

    [Required(ErrorMessage = "Join date is required")]
    [Display(Name = "Join Date")]
    public DateTime? JoinDate { get; set; }

    [Display(Name = "Last Login")]
    public DateTime? LastLogin { get; set; }

    // Use references instead of embedding
    public List<ObjectId>? PersonalRecordIds { get; set; } = new List<ObjectId>();

    public List<WeightRecord>? WeightRecords { get; set; } = new List<WeightRecord>();

    [Required(ErrorMessage = "Admin status is required")]
    public bool? IsAdmin { get; set; } = false;

    // Constructor
    public User()
    {
        Weight = WeightRecords.Count > 0 ? WeightRecords[^1].Weight : null;
    }
}
