using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sirkelen.Shared.Models;

public class Messages
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    [BsonElement("sender")]
    [Required]
    public User Sender { get; set; }

    [BsonElement("message")]
    [Required]
    public string Message { get; set; }

    [BsonElement("name")]
    [Required]
    public string Name { get; set; }

    [BsonElement("profilePicture")]
    public string? ProfilePicture { get; set; }

    [BsonElement("mediaUrl")]
    public string? MediaUrl { get; set; }

    [BsonElement("time")]
    [Required]
    public DateTime Time { get; set; }
}