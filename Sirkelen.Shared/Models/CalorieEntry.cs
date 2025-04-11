using Google.Cloud.Firestore;
using System;

namespace Sirkelen.Shared.Models
{
    [FirestoreData]
    public class CalorieEntry
    {
        [FirestoreDocumentId]
        public string Id { get; set; }

        [FirestoreProperty]
        public string UserId { get; set; }

        [FirestoreProperty]
        public Timestamp Date { get; set; }

        [FirestoreProperty]
        public int TotalCalories { get; set; }
    }
}