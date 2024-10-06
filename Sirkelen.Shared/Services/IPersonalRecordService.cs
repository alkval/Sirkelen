namespace Sirkelen.Shared.Services;
using Sirkelen.Shared.Models;
using System.Net.Http.Json;
using Sirkelen.Shared.infrastructure.Data;
using MongoDB.Bson;

public interface IPersonalRecordService
{
    Task<List<PersonalRecord>> GetPersonalRecordsAsync(ObjectId userId);
    Task AddRecordAsync(ObjectId userId, PersonalRecord record);
    Task RemoveRecordAsync(PersonalRecord record);
}