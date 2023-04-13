using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Bogus;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Retry;
using Ratings.Domain.AggregatesModel.EmployerAggregate;
using Ratings.Infrastructure;

namespace Ratings.Api;

public class RatingContextSeed
{
    public RatingContextSeed(){ }

    public async Task SeedAsync(RatingContext context, ILogger<RatingContextSeed> logger)
    {
        var policy = CreatePolicy(logger, nameof(RatingContextSeed));

        await policy.ExecuteAsync(async () =>
        {
            FakeData.Init(10, new DateTime(2022, 01, 01), new DateTime(2022, 12, 31));

            if (!context.Rankings.Any())
            {
                context.Rankings.AddRange(GetPredefinedRankings());
            }
            await context.SaveChangesAsync();

            if (!context.Employers.Any())
            {
                context.Employers.AddRange(FakeData.Employers);
            }
            await context.SaveChangesAsync();

            // restore entity state
            var Employers = context.Employers.Include(a => a.Payments)
                .ToList();

            foreach(var employer in Employers)
            {
                employer.UpdatePointRanking();
            }
            await context.SaveChangesAsync();
        });
    }

    private AsyncRetryPolicy CreatePolicy(ILogger<RatingContextSeed> logger, string prefix, int retries = 3)
    {
        return Policy.Handle<SqlException>().
            WaitAndRetryAsync(
                retryCount: retries,
                sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                onRetry: (exception, timeSpan, retry, ctx) =>
                {
                    logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", prefix, exception.GetType().Name, exception.Message, retry, retries);
                }
            );
    }

    private IEnumerable<Ranking> GetPredefinedRankings()
    {
        return new List<Ranking>()
        {
            Ranking.Platinum,
            Ranking.Gold,
            Ranking.Silver,
            Ranking.Crawler
        };
    }
}

public class PrivateBinder : Bogus.Binder
{
    public override Dictionary<string, MemberInfo> GetMembers(Type t)
    {
        var members = base.GetMembers(t);

        var privateBindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
        var allPrivateMembers = t.GetMembers(privateBindingFlags)
                                 .OfType<FieldInfo>()
                                 .Where(fi => fi.IsPrivate)
                                 .Where(fi => !fi.GetCustomAttributes(typeof(CompilerGeneratedAttribute)).Any())
                                 .ToArray();

        foreach (var privateField in allPrivateMembers)
        {
            members.TryAdd(privateField.Name, privateField);
        }
        return members;
    }
}

public class DeepFaker<T> : Faker<T> where T : class
{
    public DeepFaker(IBinder backingFieldBinder) : base(binder: backingFieldBinder)
    {
    }
    public DeepFaker<T> UsingPrivateConstructor()
    {
        return base.CustomInstantiator(f => Activator.CreateInstance(typeof(T), nonPublic: true) as T) as DeepFaker<T>;
    }
    public virtual Faker<T> RuleForPrivate<TProperty>(Expression<Func<T, TProperty>> property, TProperty value)
    {
        var propName = PropertyName.For(property);
        propName = propName.First()
                           .ToString()
                           .ToLower() +
                propName.Substring(1);
        return AddRule(propName, (f, t) => value);
    }
}

public static class FakeData
{
    public static List<Employer> Employers = new List<Employer>();
    public static List<Payment> Payments = new List<Payment>();


    static int  MonthCount = 0;
    static int Count = 0;
    public static void Init(int count, DateTime From, DateTime To)
    {
        PrivateBinder privateBinder = new PrivateBinder();
        Count = count;

        var StartingMonth = new DateTime(From.Year, From.Month, 1);

        while(StartingMonth < To)
        {
            StartingMonth = StartingMonth.AddMonths(1);
            MonthCount++;
        }

        int paymentId = 1;
        int MonthIndex = -1;
        int employerId = 0;

        var PaymentFaker = new DeepFaker<Payment>(privateBinder)
                .UsingPrivateConstructor()
                .RuleFor("Id", f => paymentId++)
                .RuleFor("_contributionMonth", f => { MonthIndex++; return GetContributionMonth(MonthIndex, From); })
                .RuleFor("_dueDate", f => GetDueDate(MonthIndex, From))
                .RuleFor("_paymentDate", f => GetPaymentDate(employerId,MonthIndex, From))
                .RuleFor("_paidAmount", f => f.Finance.Amount(500, 1000000))
                .RuleFor("_status", f => true);

        var NoPaymentFaker = new DeepFaker<Payment>(privateBinder)
                .UsingPrivateConstructor()
                .RuleFor("Id", f => paymentId++)
                .RuleFor("_contributionMonth", f => { MonthIndex++; return GetContributionMonth(MonthIndex, From); })
                .RuleFor("_dueDate", f => GetDueDate(MonthIndex, From))
                .RuleFor("_paymentDate", f => f.Date.Past(3).OrNull(f, 1))
                .RuleFor("_paidAmount", f => f.Finance.Amount(500, 1000000))
                .RuleFor("_status", f => false);

        var EmployerFaker = new DeepFaker<Employer>(privateBinder)
            .UsingPrivateConstructor()
            .RuleFor(p => p.Id, f => ++employerId)
            .RuleFor(p => p.Name, f => f.Company.CompanyName())
            .RuleFor(p => p.Points, f => f.Random.Int(-5000, 5000))
            .RuleFor(p => p.Ranking, f => f.PickRandom<Ranking>(Ranking.GetAll<Ranking>()))
            .RuleFor("_payments", _ => employerId > (Count/10) ? PaymentFaker.Generate(MonthCount) : NoPaymentFaker.Generate(MonthCount));

        var employers = EmployerFaker.Generate(count);

        FakeData.Employers.AddRange(employers);
    }

    private static DateTime GetContributionMonth(int index, DateTime From)
    {
        index = index  % MonthCount;
        var Month = new DateTime(From.Year, From.Month, 1);
        Month = Month.AddMonths(index);
        return Month;
    }

    private static DateTime GetDueDate(int index, DateTime From)
    {
        index = index  % MonthCount;
        var Month = new DateTime(From.Year, From.Month + 1, 15);
        Month = Month.AddMonths(index);
        return Month;
    }

    public static DateTime GetPaymentDate(int employerIndex, int MonthIndex, DateTime From)
    {
        int NonPaying = Count / 10;
        int PayingOnTime = Count/2 + NonPaying;
        int PayingAfterDueWithinThreeMonths = Count/5 + PayingOnTime;
        int PayingAfterDueAfterThreeMonths = Count/5 + PayingAfterDueWithinThreeMonths;

        Faker DateFaker = new Faker();

        DateTime DueDate = GetDueDate(MonthIndex, From);
        DateTime StartDate = GetContributionMonth(MonthIndex, From);


        if(employerIndex <= NonPaying) return DateTime.MaxValue;
        else if(employerIndex <= PayingOnTime) return DateFaker.Date.Between(StartDate, DueDate);
        else if (employerIndex <= PayingAfterDueWithinThreeMonths) return DateFaker.Date.Between(DueDate, DueDate.AddMonths(3));
        else return DateFaker.Date.Between(DueDate.AddMonths(3), DateTime.Now);
        
        
    }


}
