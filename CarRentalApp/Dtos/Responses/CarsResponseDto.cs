namespace CarRentalApp.Dtos.Responses;

public class CarsResponseDto
{
    public CarsResponseDto(
        int id, 
        string? make, 
        string? model, 
        int? year, 
        string? licensePlate, 
        decimal? pricePerDay, 
        InsuranceResponseDto insurance)
    {
        Id = id;
        Make = make;
        Model = model;
        Year = year;
        LicensePlate = licensePlate;
        PricePerDay = pricePerDay;
        Insurance = insurance;
    }

    public int Id { get; }

    public string? Make { get; }

    public string? Model { get; }

    public int? Year { get; }

    public string? LicensePlate { get; }

    public decimal? PricePerDay { get; }
    
    public InsuranceResponseDto Insurance { get; }
}