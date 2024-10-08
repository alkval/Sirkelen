using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Google.Apis.Auth.OAuth2;
using Grpc.Auth;
using System.IO;
using System.Threading.Tasks;
using Sirkelen.Shared.Models;
using Microsoft.Maui.Storage;
using System.Diagnostics;

namespace Sirkelen.Shared.Services
{
    public class FirebaseService
    {
        private FirestoreDb _firestoreDb;
        private bool _isInitialized = false;

        public FirebaseService(string v)
        {
            InitializeFirestore();
        }

        private async void InitializeFirestore()
        {
            try
            {
                Debug.WriteLine("Initializing Firestore...");
                using var stream = await FileSystem.OpenAppPackageFileAsync("ServiceAccount.json");
                GoogleCredential credential = GoogleCredential.FromStream(stream);
                
                var builder = new FirestoreClientBuilder
                {
                    Credential = credential
                };

                var client = await builder.BuildAsync();
                _firestoreDb = await FirestoreDb.CreateAsync("sirkelen-defba", client);
                _isInitialized = true;
                Debug.WriteLine("Firestore initialized successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error initializing Firestore: {ex.Message}");
                Debug.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }

        public async Task AddUser(User user)
        {
            if (!_isInitialized)
            {
                Debug.WriteLine("Firestore is not initialized. Waiting...");
                await Task.Delay(5000); // Wait for 5 seconds
                if (!_isInitialized)
                {
                    throw new InvalidOperationException("Firestore is not initialized.");
                }
            }

            try
            {
                Debug.WriteLine($"Adding user: {user.Name}");
                var userRef = _firestoreDb.Collection("Users").Document(user.Id);
                await userRef.SetAsync(user);
                Debug.WriteLine($"User {user.Name} added successfully.");
            }
            catch (Exception ex)
    

        {
                Debug.WriteLine($"Error adding user {user.Name}: {ex.Message}");
                Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        public async Task<List<User>> GetUsers()
        {
            var users = new List<User>();
            var snapshot = await _firestoreDb.Collection("Users").GetSnapshotAsync();
            foreach (var document in snapshot.Documents)
            {
                users.Add(document.ConvertTo<User>());
            }
            return users;
        }

        public async Task AddChatMessage(Message message)
        {
            var chatRef = _firestoreDb.Collection("ChatMessages");
            await chatRef.AddAsync(message);
        }

        public async Task<List<Message>> GetChatMessages()
        {
            if (_firestoreDb == null)
            {
                throw new InvalidOperationException("FirestoreDb has not been initialized.");
            }

            var snapshot = await _firestoreDb.Collection("ChatMessages").GetSnapshotAsync();
            
            if (snapshot == null)
            {
                throw new InvalidOperationException("Failed to retrieve messages: snapshot is null.");
            }

            var messages = new List<Message>();
            foreach (var document in snapshot.Documents)
            {
                var message = document.ConvertTo<Message>();
                messages.Add(message);
            }

            return messages;
        }
    }
}
