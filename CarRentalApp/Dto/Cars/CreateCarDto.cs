namespace CarRentalApp.Dto.Cars;

public class CreateCarDto
{
    public CreateCarDto(
        string make, 
        string model, 
        int year, 
        string licensePlate, 
        decimal pricePerDay, 
        int insuranceId)
    {
        Make = make;
        Model = model;
        Year = year;
        LicensePlate = licensePlate;
        PricePerDay = pricePerDay;
        InsuranceId = insuranceId;
    }
    public string Make { get; }

    public string Model { get; }

    public int Year { get; }

    public string LicensePlate { get; }

    public decimal PricePerDay { get; }
    
    public int InsuranceId { get; }
}