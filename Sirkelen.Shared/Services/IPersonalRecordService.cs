namespace Sirkelen.Shared.Services;
using Sirkelen.Shared.Models;
using System.Net.Http.Json;
using MongoDB.Bson;

public interface IPersonalRecordService
{
    Task<List<PersonalRecord>> GetPersonalRecordsAsync(string userId);
    Task AddRecordAsync(string userId, PersonalRecord record);
    Task RemoveRecordAsync(PersonalRecord record);
}