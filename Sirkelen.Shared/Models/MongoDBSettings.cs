using MongoDB.Bson.Serialization.Attributes;

namespace Sirkelen.Shared.Models;

public class MongoDBSettings
{
    [BsonElement("connectionString")]
    public string? ConnectionString { get; set; }

    [BsonElement("databaseName")]
    public string? DatabaseName { get; set; }
}