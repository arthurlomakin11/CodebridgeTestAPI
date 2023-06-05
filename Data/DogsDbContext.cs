using Microsoft.EntityFrameworkCore;

namespace CodebridgeTestAPI;

public class DogsDbContext: DbContext
{
    public DbSet<Dog> Dogs { get; set; }
    public DogsDbContext(DbContextOptions<DogsDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dog>().HasData(SampleData.DogsListWithId);
    }
}