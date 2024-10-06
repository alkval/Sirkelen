using Microsoft.EntityFrameworkCore;
using Sirkelen.Shared.Models;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;


namespace Sirkelen.Shared.infrastructure.Data;
public class SirkelenContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<PersonalRecord> PersonalRecords { get; set; }
    public DbSet<WeightRecord> WeightRecords { get; set; }
    public DbSet<Message> Messages { get; set; }

    public SirkelenContext(DbContextOptions<SirkelenContext> options) : base(options) 
    { 
    }
    public SirkelenContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>();
        modelBuilder.Entity<PersonalRecord>();
        modelBuilder.Entity<WeightRecord>();
        modelBuilder.Entity<Message>();
    }
}