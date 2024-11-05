using CarRentalApp.Dto.Insurances;

namespace CarRentalApp.Dto.Cars;

public class CarDto
{
    public CarDto(
        int id, 
        string? make, 
        string? model, 
        int? year, 
        string? licensePlate, 
        decimal? pricePerDay, 
        InsuranceDto insurance)
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
    
    public InsuranceDto Insurance { get; }
}