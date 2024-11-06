namespace CarRentalApp.Entities;

public class Car
{
    public int Id { get; init; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }

    public string? LicensePlate { get; set; }

    public decimal? PricePerDay { get; set; }

    public int InsuranceId { get; init; }

    public virtual Insurance Insurance { get; init; } = null!;
}
