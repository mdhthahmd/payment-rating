// using Ratings.Domain.SeedWork;

// namespace Ratings.Domain.AggregatesModel.EmployerAggregate;

// public class PaymentStatus : Enumeration
// {
//     public PaymentStatus(int id, string name) : base(id, name)
//     { }

//     public static PaymentStatus Pending = new PaymentStatus(1, nameof(Pending));
//     public static PaymentStatus Paid = new PaymentStatus(2, nameof(Paid));

//     public static IEnumerable<PaymentStatus> List() =>
//         new[] { Pending, Paid };

//     public static PaymentStatus FromName(string name)
//     {
//         var state = List()
//             .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

//         if (state == null)
//         {
//             throw new Exception($"Possible values for PaymentStatus: {String.Join(",", List().Select(s => s.Name))}");
//         }

//         return state;
//     }

//     public static PaymentStatus From(int id)
//     {
//         var state = List().SingleOrDefault(s => s.Id == id);

//         if (state == null)
//         {
//             throw new Exception($"Possible values for PaymentStatus: {String.Join(",", List().Select(s => s.Name))}");
//         }

//         return state;
//     }
// }
