using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

namespace Sirkelen.Shared.Models
{
    [FirestoreData]
    public class User
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public int Rank { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public string Username { get; set; }

        [FirestoreProperty]
        public string Password { get; set; }

        [FirestoreProperty]
        public string ProfilePictureUrl { get; set; }

        [FirestoreProperty]
        public double Height { get; set; }

        [FirestoreProperty]
        public double Weight { get; set; } // Changed to double

        [FirestoreProperty]
        public DateTime JoinDate { get; set; }

        [FirestoreProperty]
        public DateTime? LastLogin { get; set; }

        [FirestoreProperty]
        public List<string> PersonalRecordIds { get; set; } = new List<string>();

        [FirestoreProperty]
        public List<string> WeightRecordIds { get; set; } = new List<string>();

        [FirestoreProperty]
        public bool IsAdmin { get; set; }

        // Constructor to ensure UTC dates
        public User()
        {
            JoinDate = DateTime.UtcNow;
            LastLogin = DateTime.UtcNow;
        }
    }
}