namespace CarRentalApp.Dtos.Requests;

public class CarRequestDto
{
    public CarRequestDto(
        string? make, 
        string? model, 
        int? year, 
        string? licensePlate, 
        decimal? pricePerDay, 
        int insuredId)
    {
        Make = make;
        Model = model;
        Year = year;
        LicensePlate = licensePlate;
        PricePerDay = pricePerDay;
        InsuranceId = insuredId;
    }

    public string? Make { get; }

    public string? Model { get; }

    public int? Year { get; }

    public string? LicensePlate { get; }

    public decimal? PricePerDay { get; }
    
    public int InsuranceId { get; }
}