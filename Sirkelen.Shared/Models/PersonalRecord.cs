using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sirkelen.Shared.Models;

public class PersonalRecord
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; } // Primary key

    [BsonElement("userId")]
    [BsonRepresentation(BsonType.String)]
    public Guid UserId { get; set; } // Foreign key

    [BsonIgnore]
    public User User { get; set; } // Navigation property

    [BsonElement("exerciseName")]
    [Required]
    public string ExerciseName { get; set; }

    [BsonElement("weight")]
    [BsonRepresentation(BsonType.Decimal128)]
    [Required]
    public decimal Weight { get; set; }

    [BsonElement("reps")]
    [Required]
    public int Reps { get; set; }

    [BsonElement("sets")]
    [Required]
    public int Sets { get; set; }

    [BsonElement("date")]
    [Required]
    public DateTime Date { get; set; }
}