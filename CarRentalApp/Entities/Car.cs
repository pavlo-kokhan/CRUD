namespace CarRentalApp.Entities;

public sealed class Car
{
    public int Id { get; init; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }

    public string? LicensePlate { get; set; }

    public decimal? PricePerDay { get; set; }

    public int InsuranceId { get; init; }

    public Insurance Insurance { get; init; } = null!;
}
