using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;

namespace Sirkelen.Shared.Models
{
    [FirestoreData]
    public class PersonalRecord
    {
        [FirestoreDocumentId]
        public string Id { get; set; } // Primary key

        [Required]
        [FirestoreProperty]
        public string UserId { get; set; } // Foreign key

        [Required]
        [FirestoreProperty]
        public string ExerciseName { get; set; }

        [Required]
        [FirestoreProperty]
        public double Weight { get; set; }

        [Required]
        [FirestoreProperty]
        public int Reps { get; set; }

        [Required]
        [FirestoreProperty]
        public int Sets { get; set; }

        [Required]
        [FirestoreProperty]
        public DateTime Date { get; set; }
    }
}
