using CarRentalAppCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAppCodeFirst.Contexts;

public class CarsRentalDbContext : DbContext
{
    public CarsRentalDbContext()
    {
    }

    public CarsRentalDbContext(DbContextOptions<CarsRentalDbContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Insurance> Insurances { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=CarsRentalDb_2;Username=postgres;Password=");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasOne(c => c.Insurance)
            .WithMany(c => c.Cars)
            .HasForeignKey(c => c.InsuranceId)
            .IsRequired();
        
        base.OnModelCreating(modelBuilder);
    }
}