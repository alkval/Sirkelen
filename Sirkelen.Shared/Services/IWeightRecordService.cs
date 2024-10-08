using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sirkelen.Shared.Models;

using System.Net.Http.Json;
using MongoDB.Bson;

namespace Sirkelen.Shared.Services
{
    public interface IWeightRecordService
    {
        Task<List<WeightRecord>> GetWeightRecordsAsync(string userId);
        Task AddWeightRecordAsync(WeightRecord weightRecord);
        // Add other methods as needed
    }
}