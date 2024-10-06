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
    public class WeightRecordService : IWeightRecordService
    {
        private readonly SirkelenContext _context;

        public WeightRecordService(SirkelenContext context)
        {
            _context = context;
        }

        public async Task<List<WeightRecord>> GetWeightRecordsAsync(ObjectId userId)
        {
            return await _context.WeightRecords
                .Where(wr => wr.UserId == userId)
                .OrderByDescending(wr => wr.Date)
                .ToListAsync();
        }

        public async Task AddWeightRecordAsync(WeightRecord weightRecord)
        {
            _context.WeightRecords.Add(weightRecord);
            await _context.SaveChangesAsync();
        }

        // You can add more methods here as needed, such as:
        
        public async Task UpdateWeightRecordAsync(WeightRecord weightRecord)
        {
            _context.WeightRecords.Update(weightRecord);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWeightRecordAsync(ObjectId recordId)
        {
            var record = await _context.WeightRecords.FindAsync(recordId);
            if (record != null)
            {
                _context.WeightRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}