using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

[Collection("PersonalRecords")]
public class PersonalRecord
{
    public ObjectId Id { get; set; } // Primary key

    [BsonElement("userId")]
    public ObjectId UserId { get; set; } // Foreign key

    [BsonElement("exerciseName")]
    [Required]
    public string? ExerciseName { get; set; }

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