using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Google.Apis.Auth.OAuth2;
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
            
            InitializeFirestore().GetAwaiter().GetResult();
        }

        private async Task InitializeFirestore()
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
            await EnsureInitialized();

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
            await EnsureInitialized();

            var users = new List<User>();
            var snapshot = await _firestoreDb.Collection("Users").GetSnapshotAsync();
            foreach (var document in snapshot.Documents)
            {
                users.Add(document.ConvertTo<User>());
            }
            return users;
        }

        public async Task<VersionInfo> GetLatestVersionInfo()
        {
            await EnsureInitialized();
            
            try
            {
                var configDoc = await _firestoreDb.Collection("Config").Document("VersionInfo").GetSnapshotAsync();
                if (configDoc.Exists)
                {
                    return configDoc.ConvertTo<VersionInfo>();
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error getting version info: {ex.Message}");
                return null;
            }
        }
        
        public async Task AddPersonalRecord(PersonalRecord record)
        {
            await EnsureInitialized();
            var recordRef = _firestoreDb.Collection("PersonalRecords").Document();
            await recordRef.SetAsync(record);

            // Update user's PersonalRecordIds
            var userRef = _firestoreDb.Collection("Users").Document(record.UserId);
            await userRef.UpdateAsync("PersonalRecordIds", FieldValue.ArrayUnion(recordRef.Id));
        }

        public async Task DeletePersonalRecord(string recordId, string userId)
        {
            await EnsureInitialized();
            
            var recordRef = _firestoreDb.Collection("PersonalRecords").Document(recordId);
            await recordRef.DeleteAsync();
            
            Debug.WriteLine($"Personal record {recordId} deleted successfully.");
        }

        public async Task<List<PersonalRecord>> GetPersonalRecords(string userId)
        {
            await EnsureInitialized();
            var snapshot = await _firestoreDb.Collection("PersonalRecords")
                .WhereEqualTo("UserId", userId)
                .GetSnapshotAsync();

            return snapshot.Documents.Select(d => d.ConvertTo<PersonalRecord>()).ToList();
        }

        public async Task AddWeightRecord(WeightRecord record)
        {
            await EnsureInitialized();
            var recordRef = _firestoreDb.Collection("WeightRecords").Document();
            await recordRef.SetAsync(record);

            // Update user's WeightRecordIds and current Weight
            var userRef = _firestoreDb.Collection("Users").Document(record.UserId);
            await userRef.UpdateAsync(new Dictionary<string, object>
            {
                { "WeightRecordIds", FieldValue.ArrayUnion(recordRef.Id) },
                { "Weight", record.Weight }
            });
        }

        public async Task DeleteWeightRecord(string weightRecordId, string userId)
        {
            await EnsureInitialized();
            
            var recordRef = _firestoreDb.Collection("WeightRecords").Document(weightRecordId);
            await recordRef.DeleteAsync();

            var userRef = _firestoreDb.Collection("Users").Document(userId);
            await userRef.UpdateAsync("WeightRecordIds", FieldValue.ArrayRemove(weightRecordId));
            
            Debug.WriteLine($"Weight record {weightRecordId} deleted successfully.");
        }


        public event Action<Message> OnNewMessageReceived;

        public async Task ListenForChatMessages()
        {
            await EnsureInitialized();

            var chatRef = _firestoreDb.Collection("ChatMessages");

            chatRef.Listen(async snapshot =>
            {
                foreach (var doc in snapshot.Documents)
                {
                    var newMessage = doc.ConvertTo<Message>();
                    Debug.WriteLine($"New message received: {newMessage.MessageContent}");

                    await GetChatMessages();
                    OnNewMessageReceived?.Invoke(newMessage);
                }
            });
        }


        public async Task<List<WeightRecord>> GetWeightRecords(string userId)
        {
            await EnsureInitialized();
            var snapshot = await _firestoreDb.Collection("WeightRecords")
                .WhereEqualTo("UserId", userId)
                .OrderByDescending("Date")
                .GetSnapshotAsync();

            return snapshot.Documents.Select(d => d.ConvertTo<WeightRecord>()).ToList();
        }

        public async Task UpdateUserWeight(string userId)
        {
            await EnsureInitialized();
            var latestWeightRecord = await GetWeightRecords(userId);
            if (latestWeightRecord.Any())
            {
                var userRef = _firestoreDb.Collection("Users").Document(userId);
                await userRef.UpdateAsync("Weight", latestWeightRecord.First().Weight);
            }
        }

        public async Task AddChatMessage(Message message)
        {
            await EnsureInitialized();

            var chatRef = _firestoreDb.Collection("ChatMessages");
            await chatRef.AddAsync(message);
        }

        public async Task<List<Message>> GetChatMessages()
        {
            await EnsureInitialized();

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
        public async Task UpdateUserBMI(string userId, double bmi)
        {
            await EnsureInitialized();
            var userRef = _firestoreDb.Collection("Users").Document(userId);
            await userRef.UpdateAsync("BMI", bmi);
        }
        private async Task EnsureInitialized()
        {
            if (!_isInitialized)
            {
                Debug.WriteLine("Firestore is not initialized. Waiting...");
                await Task.Delay(5000);
                if (!_isInitialized)
                {
                    throw new InvalidOperationException("Firestore is not initialized.");
                }
            }
        }
        
    }
}
