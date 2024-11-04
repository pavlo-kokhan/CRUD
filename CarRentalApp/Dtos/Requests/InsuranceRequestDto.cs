namespace CarRentalApp.Dtos.Requests;

public class InsuranceRequestDto
{
    public InsuranceRequestDto(
        string? company, 
        string? policyNumber, 
        DateOnly? startDate, 
        DateOnly? endDate, 
        decimal? price)
    {
        Company = company;
        PolicyNumber = policyNumber;
        StartDate = startDate;
        EndDate = endDate;
        Price = price;
    }

    public string? Company { get; }

    public string? PolicyNumber { get; }

    public DateOnly? StartDate { get; }

    public DateOnly? EndDate { get; }

    public decimal? Price { get; }
}