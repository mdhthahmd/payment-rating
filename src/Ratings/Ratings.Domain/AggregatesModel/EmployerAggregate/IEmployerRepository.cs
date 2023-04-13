using Ratings.Domain.SeedWork;

namespace Ratings.Domain.AggregatesModel.EmployerAggregate;

public interface IEmployerRepository : IRepository<Employer>
{
    Employer Add(Employer employer);
    void Update(Employer employer);
    Task<Employer> GetAsync(int employerId);
}