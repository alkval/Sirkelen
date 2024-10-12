using System;
using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;

namespace Sirkelen.Shared.Models
{
    [FirestoreData]
    public class Message
    {
        [FirestoreDocumentId]
        public string Id { get; set; } // Unique identifier for each message

        [Required]
        [FirestoreProperty]
        public string UserId { get; set; } // The user who sent the message

        [Required]
        [FirestoreProperty]
        public string MessageContent { get; set; } // Content of the message

        [Required]
        [FirestoreProperty]
        public DateTime Time { get; set; } // Timestamp for when the message was sent
        public Message()
        {
            Time = DateTime.UtcNow;
        }
    }
    
    
}
