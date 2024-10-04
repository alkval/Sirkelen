using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sirkelen.Shared.Models;
using Sirkelen.Shared.infrastructure.Data;

using System.Net.Http.Json;

namespace Sirkelen.Shared.Services
{
    public interface IWeightRecordService
    {
        Task<List<WeightRecord>> GetWeightRecordsAsync(Guid userId);
        Task AddWeightRecordAsync(WeightRecord weightRecord);
        // Add other methods as needed
    }
}