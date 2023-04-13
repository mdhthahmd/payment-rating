// Console.WriteLine("Hello, World!");


using System.Text.Json;
using Bogus;


namespace DataGenerator;

public class Program
{
    private static void Main(string[] args)
    {

        FakeData.Init(100, new DateTime(2020,1,1), new DateTime(2022,1,1));

        var text = JsonSerializer.Serialize(FakeData.Employers, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(text);
    }
}

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

        var status = EmployerFaker.Generate(count);

        FakeData.Employers.AddRange(status);
      }
   }