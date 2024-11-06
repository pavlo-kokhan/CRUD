using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalAppCodeFirst.Entities;

public class Insurance
{
    [Key]
    [Column("id")]
    public int Id { get; init; }

    [Column("company")]
    public string? Company { get; set; }

    [Column("policy_number")]
    public string? PolicyNumber { get; set; }

    [Column("start_date")]
    public DateOnly? StartDate { get; set; }

    [Column("end_date")]
    public DateOnly? EndDate { get; set; }

    [Column("price")]
    public decimal? Price { get; set; }

    public virtual ICollection<Car> Cars { get; init; } = new List<Car>();
}