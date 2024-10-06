using Microsoft.EntityFrameworkCore;
using Sirkelen.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sirkelen.Shared.Models;
using System.Net.Http.Json;
using Sirkelen.Shared.infrastructure.Data;
using MongoDB.Bson;

namespace Sirkelen.Shared.Services
{
    public class PersonalRecordService : IPersonalRecordService
    {
        private readonly SirkelenContext _context;

        public PersonalRecordService(SirkelenContext context)
        {
            _context = context;
        }

        public async Task<List<PersonalRecord>> GetPersonalRecordsAsync(ObjectId userId)
        {
            return await _context.PersonalRecords
                .Where(pr => pr.UserId == userId)
                .OrderByDescending(pr => pr.Date)
                .ToListAsync();
        }

        public async Task AddRecordAsync(ObjectId userId, PersonalRecord record)
        {
            record.UserId = userId;
            _context.PersonalRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRecordAsync(PersonalRecord record)
        {
            _context.PersonalRecords.Remove(record);
            await _context.SaveChangesAsync();
        }

        // You can add more methods here as needed, such as:

        public async Task UpdateRecordAsync(PersonalRecord record)
        {
            _context.PersonalRecords.Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task<PersonalRecord> GetRecordByIdAsync(ObjectId recordId)
        {
            return await _context.PersonalRecords.FindAsync(recordId);
        }
    }
}