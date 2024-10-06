using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sirkelen.Shared.Models;

public class WeightRecord
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; } // Primary key

    [BsonIgnore]
    public User User { get; set; } // Navigation property

    [BsonElement("userId")]
    [BsonRepresentation(BsonType.String)]
    public Guid UserId { get; set; } // Foreign key

    [BsonElement("weight")]
    [BsonRepresentation(BsonType.Decimal128)]
    [Required]
    public decimal Weight { get; set; }

    [BsonElement("date")]
    [Required]
    public DateTime Date { get; set; }
}