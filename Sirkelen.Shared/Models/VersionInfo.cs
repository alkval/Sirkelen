using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;

namespace Sirkelen.Shared.Models
{
    [FirestoreData]
    public class VersionInfo
    {
        [Required]
        [FirestoreProperty]
        public string Version { get; set; }

        [Required]
        [FirestoreProperty]
        public string UpdateUrl { get; set; }

        [Required]
        [FirestoreProperty]
        public string UpdateNotes { get; set; }


    }
    
    
}
