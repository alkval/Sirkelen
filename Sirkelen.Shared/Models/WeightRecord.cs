using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

[Collection("WeightRecords")]
public class WeightRecord
{
    public ObjectId Id { get; set; } // Primary key

    [BsonElement("userId")]
    public ObjectId UserId { get; set; } // Foreign key

    [Required(ErrorMessage = "Weight is required")]
    [Display(Name = "Weight")]
    public decimal? Weight { get; set; }

    [Required(ErrorMessage = "Date is required")]
    [Display(Name = "Date")]
    public DateTime? Date { get; set; }
}
