namespace CarRentalApp.Dtos.Responses;

public class InsuranceResponseDto
{
    public InsuranceResponseDto(
        int id, 
        string? company, 
        string? policyNumber, 
        DateOnly? startDate, 
        DateOnly? endDate, 
        decimal? price)
    {
        Id = id;
        Company = company;
        PolicyNumber = policyNumber;
        StartDate = startDate;
        EndDate = endDate;
        Price = price;
    }

    public int Id { get; }

    public string? Company { get; }

    public string? PolicyNumber { get; }

    public DateOnly? StartDate { get; }

    public DateOnly? EndDate { get; }

    public decimal? Price { get; }
}