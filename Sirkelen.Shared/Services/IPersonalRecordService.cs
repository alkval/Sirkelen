namespace Sirkelen.Shared.Services;
using Sirkelen.Shared.Models;
using System.Net.Http.Json;
using Sirkelen.Shared.infrastructure.Data;

public interface IPersonalRecordService
{
    Task<List<PersonalRecord>> GetPersonalRecordsAsync(Guid userId);
    Task AddRecordAsync(Guid userId, PersonalRecord record);
    Task RemoveRecordAsync(PersonalRecord record);
}