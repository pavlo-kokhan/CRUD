namespace CarRentalApp.Entities;

public sealed class Insurance
{
    public int Id { get; init; }

    public string? Company { get; set; }

    public string? PolicyNumber { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? Price { get; set; }

    public ICollection<Car> Cars { get; init; } = new List<Car>();
}
