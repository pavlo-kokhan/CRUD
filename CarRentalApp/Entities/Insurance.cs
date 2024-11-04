namespace CarRentalApp.Entities;

public partial class Insurance
{
    public int Id { get; set; }

    public string? Company { get; set; }

    public string? PolicyNumber { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
