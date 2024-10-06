using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

namespace Sirkelen.Shared.Models;

[Collection("Messages")] // Use a collection for messages
public class Message
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public ObjectId Id { get; set; } // Unique identifier for each message

    [BsonElement("senderId")]
    [Required]
    public ObjectId SenderId { get; set; } // Use UserId instead of the entire User object

    [BsonElement("message")]
    [Required]
    public string? MessageContent { get; set; } // Rename to avoid confusion

    [BsonElement("time")]
    [Required]
    public DateTime Time { get; set; } // Timestamp for the message
}
