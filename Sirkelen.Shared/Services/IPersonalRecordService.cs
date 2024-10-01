public interface IPersonalRecordService
{
    Task<List<PersonalRecord>> GetPersonalRecordsAsync(Guid userId);
    Task AddRecordAsync(Guid userId, PersonalRecord record);
    Task RemoveRecordAsync(PersonalRecord record);
}