using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sirkelen.Shared.Models;
using Sirkelen.Shared.infrastructure.Data;

using System.Net.Http.Json;
using MongoDB.Bson;

namespace Sirkelen.Shared.Services
{
    public interface IWeightRecordService
    {
        Task<List<WeightRecord>> GetWeightRecordsAsync(ObjectId userId);
        Task AddWeightRecordAsync(WeightRecord weightRecord);
        // Add other methods as needed
    }
}