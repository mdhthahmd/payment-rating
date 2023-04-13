using Bogus;
using Ratings.Domain.AggregatesModel.EmployerAggregate;

namespace Ratings.Infrastructure;

public static class FakeData
{
    public static List<Employer> Employers = new List<Employer>();

    // public static List<Post> Posts = new List<Post>();
    public static List<Payment> Payments = new List<Payment>();

    public static void Init(int count, DateTime From, DateTime To)
    {
      //   int employerId = 1;
      //   var EmployerFaker = new Faker<Employer>()
      //      .RuleFor(p => p.Id, f => employerId++)
      //      .RuleFor(p => p.Name, f => f.Company.CompanyName());

      //   var employers = EmployerFaker.Generate(count);

      //   FakeData.Employers.AddRange(employers);

      int paymentId = 1;
      var PaymentFaker = new Faker<Payment>()
         .RuleFor(a => a.Id, f => paymentId++)
         .RuleFor(a => a.EmployerId, f => 1)
         .RuleFor(a => a.ContributionMonth, f => f.Date.Past(3))
         .RuleFor(a => a.DueDate, f => f.Date.Past(3))
         .RuleFor(a => a.PaymentDate, f => f.Date.Past(3))
         .RuleFor(a => a.PaidAmount, f => f.Finance.Amount(50000, 1000000))
         .RuleFor(a => a.Status, f => f.PickRandom<bool>());
      

    }
}