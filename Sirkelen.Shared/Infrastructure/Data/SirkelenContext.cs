using Microsoft.EntityFrameworkCore;

public class SirkelenContext : DbContext
{
    public SirkelenContext(DbContextOptions<SirkelenContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<PersonalRecord> PersonalRecords { get; set; }
    public DbSet<WeightRecord> WeightRecords { get; set; }
    public DbSet<Messages> Messages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=sirkelen.db");
    }
}