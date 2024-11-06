using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalAppCodeFirst.Entities;

[Table("cars")]
public class Car
{
    [Key]
    [Column("id")]
    public int Id { get; init; }

    [Column("make")]
    public string? Make { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("year")]
    public int? Year { get; set; }

    [Column("license_plate")]
    public string? LicensePlate { get; set; }

    [Column("price_per_day")]
    public decimal? PricePerDay { get; set; }

    [ForeignKey("insurance_id")]
    public int InsuranceId { get; init; }

    public virtual Insurance Insurance { get; init; } = null!;
}