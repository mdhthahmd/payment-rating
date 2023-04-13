using Microsoft.EntityFrameworkCore;
using Ratings.Domain.AggregatesModel.EmployerAggregate;
using Ratings.Domain.SeedWork;

namespace Ratings.Infrastructure.Repositories;

public class EmployerRepository : IEmployerRepository
{
    private readonly RatingContext _context;

    public IUnitOfWork UnitOfWork => _context;

    

    public EmployerRepository(RatingContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Employer> GetByIdAsync(int employerId)
    {
        var employer = await _context
                            .Employers
                            .FirstOrDefaultAsync(o => o.Id == employerId);
        if (employer == null)
        {
            employer = _context
                        .Employers
                        .Local
                        .FirstOrDefault(o => o.Id == employerId);
        }
        if (employer != null)
        {
            await _context.Entry(employer)
                .Collection(i => i.Payments).LoadAsync();
            await _context.Entry(employer)
                .Reference(i => i.Ranking).LoadAsync();
        }

        return employer;
    }
   
   
    public void Update(Employer employer)
    {
        _context.Entry(employer).State = EntityState.Modified;
    }

}