using Ratings.Domain.SeedWork;

namespace Ratings.Domain.AggregatesModel.EmployerAggregate;

public class Employer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Payment> Payments { get; set; }  = new List<Payment>();
}