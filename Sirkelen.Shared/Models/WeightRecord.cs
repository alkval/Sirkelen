using System;
using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;
namespace Sirkelen.Shared.Models;

[FirestoreData]
public class WeightRecord
{
    [FirestoreDocumentId]
    public string? Id { get; set; } // Primary key

    [FirestoreProperty]
    public string? UserId { get; set; } // Foreign key
    [FirestoreProperty]
    public double Weight { get; set; }

    [FirestoreProperty]
    public DateTime? Date { get; set; }
}
