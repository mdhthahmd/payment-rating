using Ratings.Domain.SeedWork;

namespace Ratings.Domain.AggregatesModel.EmployerAggregate;

public interface IEmployerRepository 
{
    Employer Add(Employer employer);
    void Update(Employer employer);
    Task<Employer> GetAsync(int employerId);
}