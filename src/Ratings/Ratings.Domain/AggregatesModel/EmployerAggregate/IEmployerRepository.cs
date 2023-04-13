using Ratings.Domain.SeedWork;

namespace Ratings.Domain.AggregatesModel.EmployerAggregate;

public interface IEmployerRepository : IRepository<Employer>
{
    Task<Employer> GetByIdAsync(int employerId);
    void Update(Employer employer);


}