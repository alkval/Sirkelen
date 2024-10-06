using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sirkelen.Shared.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; } // Primary key

    [BsonElement("rank")]
    public int? Rank { get; set; }

    [BsonElement("name")]
    [Required]
    public string Name { get; set; }

    [BsonElement("username")]
    [Required]
    public string Username { get; set; }

    [BsonElement("passwordHash")]
    [Required]
    public string PasswordHash { get; set; }

    [BsonElement("profilePictureUrl")]
    public string? ProfilePictureUrl { get; set; }

    [BsonElement("height")]
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal? Height { get; set; }

    [BsonElement("weight")]
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal? Weight { get; set; }

    [BsonElement("joinDate")]
    [Required]
    public DateTime JoinDate { get; set; }

    [BsonElement("lastLogin")]
    public DateTime? LastLogin { get; set; }

    [BsonElement("personalRecords")]
    public List<PersonalRecord> PersonalRecords { get; set; } = new List<PersonalRecord>();

    [BsonElement("weightRecords")]
    public List<WeightRecord> WeightRecords { get; set; } = new List<WeightRecord>();

    [BsonElement("isAdmin")]
    [Required]
    public bool IsAdmin { get; set; } = false;

    public User()
    {
        Weight = WeightRecords.LastOrDefault()?.Weight;
    }
}