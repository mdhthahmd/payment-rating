using Ratings.Domain.SeedWork;

namespace Ratings.Domain.AggregatesModel.EmployerAggregate;

public class Employer : Entity, IAggregateRoot
{
    public string Name { get; private set; }

    private readonly List<Payment> _payments = new List<Payment>();
    public IReadOnlyCollection<Payment> Payments => _payments;
}