using Microsoft.EntityFrameworkCore;
using Sirkelen.Shared.Models;

namespace Sirkelen.Shared.infrastructure.Data;
public class SirkelenContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<PersonalRecord> PersonalRecords { get; set; }
    public DbSet<WeightRecord> WeightRecords { get; set; }
    public DbSet<Messages> Messages { get; set; }

    public SirkelenContext(DbContextOptions<SirkelenContext> options) : base(options) 
    { 
    }
    public SirkelenContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.PersonalRecords)
            .WithOne(pr => pr.User)
            .HasForeignKey(pr => pr.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.WeightRecords)
            .WithOne(wr => wr.User)
            .HasForeignKey(wr => wr.UserId);

        modelBuilder.Entity<User>().HasData(
            new User { Id = Guid.NewGuid(), Name = "Alex", Username = "admin", PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"), JoinDate = DateTime.Now, IsAdmin = true },
            new User { Id = Guid.NewGuid(), Name = "Atle", Username = "atse02", PasswordHash = BCrypt.Net.BCrypt.HashPassword("atse02"), JoinDate = DateTime.Now, IsAdmin = false },
            new User { Id = Guid.NewGuid(), Name = "Brage", Username = "bragstern", PasswordHash = BCrypt.Net.BCrypt.HashPassword("bragstern"), JoinDate = DateTime.Now, IsAdmin = false },
            new User { Id = Guid.NewGuid(), Name = "Sander", Username = "sandercool", PasswordHash = BCrypt.Net.BCrypt.HashPassword("sandercool"), JoinDate = DateTime.Now, IsAdmin = false },
            new User { Id = Guid.NewGuid(), Name = "Vuong", Username = "vuonguyen", PasswordHash = BCrypt.Net.BCrypt.HashPassword("vuonguyen"), JoinDate = DateTime.Now, IsAdmin = false }

        );
    }
}