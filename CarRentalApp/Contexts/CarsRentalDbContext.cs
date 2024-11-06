using CarRentalApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Contexts;

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
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=CarsRentalDb;Username=postgres;Password=");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cars_pkey");

            entity.ToTable("cars");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.InsuranceId)
                .HasDefaultValue(1)
                .HasColumnName("insurance_id");
            entity.Property(e => e.LicensePlate)
                .HasMaxLength(255)
                .HasColumnName("license_plate");
            entity.Property(e => e.Make)
                .HasMaxLength(255)
                .HasColumnName("make");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasColumnName("model");
            entity.Property(e => e.PricePerDay)
                .HasPrecision(18, 2)
                .HasColumnName("price_per_day");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Insurance).WithMany(p => p.Cars)
                .HasForeignKey(d => d.InsuranceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("insurance_id_fk");
        });

        modelBuilder.Entity<Insurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("incurances_pkey");

            entity.ToTable("insurances");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Company)
                .HasMaxLength(255)
                .HasColumnName("company");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(255)
                .HasColumnName("policy_number");
            entity.Property(e => e.Price)
                .HasPrecision(18, 2)
                .HasColumnName("price");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
        });
    }
}
