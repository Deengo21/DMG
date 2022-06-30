using Microsoft.EntityFrameworkCore;

namespace dmg.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Character> Character { get; set; }
    public DbSet<Weapon> Weapons {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>().ToTable("character").HasKey(c => c.Id);
        
        modelBuilder.Entity<Character>().HasData(new Character()
        {
            Id = 1,
            Name = "Thomas",
            Shooting = 10,
            Strength = 10,
            MeleCombat = 15
        });
        base.OnModelCreating(modelBuilder);
    }

}