using Bogus;
using Ratings.Domain.AggregatesModel.EmployerAggregate;

namespace Ratings.Infrastructure;

public static class FakeData
{
    public static List<Employer> Employers = new List<Employer>();
    // public static List<Post> Posts = new List<Post>();
    //public static List<PaymentStatus> Status = new List<PaymentStatus>();

    public static void Init(int count, DateTime From, DateTime To)
    {
        int employerId = 1;
        var EmployerFaker = new Faker<Employer>()
           .RuleFor(p => p.Id, f => employerId++)
           .RuleFor(p => p.Name, f => f.Company.CompanyName());

        var employers = EmployerFaker.Generate(count);

        FakeData.Employers.AddRange(employers);
    }
}