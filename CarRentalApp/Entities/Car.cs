namespace CarRentalApp.Entities;

public partial class Car
{
    public int Id { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }

    public string? LicensePlate { get; set; }

    public decimal? PricePerDay { get; set; }

    public int InsuranceId { get; set; }

    public virtual Insurance Insurance { get; set; } = null!;
}
