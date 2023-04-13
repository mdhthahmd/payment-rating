using Ratings.Domain.SeedWork;

namespace Ratings.Domain.AggregatesModel.EmployerAggregate;

public class Ranking : Enumeration
{
    public Ranking(int id, string name) : base(id, name)
    { }

    public static Ranking Platinum = new Ranking(5, nameof(Platinum));
    public static Ranking Gold = new Ranking(4, nameof(Gold));
    public static Ranking Silver = new Ranking(3, nameof(Silver));
    public static Ranking Crawler = new Ranking(0, nameof(Crawler));


    public static IEnumerable<Ranking> List() =>
        new[] { Platinum, Gold, Silver, Crawler  };

    public static Ranking FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (state == null)
        {
            throw new Exception($"Possible values for Ranking: {String.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static Ranking From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state == null)
        {
            throw new Exception($"Possible values for Ranking: {String.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }
}
