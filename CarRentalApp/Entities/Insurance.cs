namespace CarRentalApp.Entities;

public class Insurance
{
    public int Id { get; init; }

    public string? Company { get; set; }

    public string? PolicyNumber { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<Car> Cars { get; init; } = new List<Car>();
}
