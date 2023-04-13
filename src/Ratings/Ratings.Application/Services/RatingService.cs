// using System.Data.SqlClient;
// using Dapper;
// using Microsoft.Extensions.Configuration;
// using Ratings.Application.Queries;
// using Ratings.Domain.AggregatesModel.EmployerAggregate;

// namespace Ratings.Application.Services;

// public class RatingService : IRatingService
// {
//      private readonly IConfiguration _config;
//      private readonly IEmployerRepository _employerRepository;

//      public RatingService(IConfiguration config, IEmployerRepository employerRepository)
//      {
//         _config = config;
//         _employerRepository = employerRepository;
//      }
//     public async void Init()
//     {
//         using var connection = new SqlConnection(_config["ConnectionString"]);
//         connection.Open();
//         var employers = await connection.QueryAsync<int>
//             ("SELECT rating.employers.id FROM rating.employers;");

//         foreach(var employerId in employers)
//         {
//             Update(employerId);
//         }
//     }

//     public async void Update(int employerId)
//     {
//         using var connection = new SqlConnection(_config["ConnectionString"]);
//         connection.Open();
//         var payments = await connection.QueryAsync<PaymentHistoryDto>
//             (@"SELECT 
//                 p.id as Id,
//                 p.employer_id as EmployerId,
//                 p.paid_amount as Amount,
//                 p.contribution_month as ContributionMonth,
//                 p.due_date as DueDate,
//                 p.paid_amount as Amount,
//                 p.payment_date as PaymentDate,
//                 p.[status]
//             FROM rating.payments as p 
//             WHERE p.employer_id = @EmployerId", new { EmployerId = employerId });

//         int points = CalculatePoints(payments);
//         Ranking ranking = CalculateStars(payments);

//         await connection.QueryAsync
//             (@"UPDATE rating.employers SET [ranking_id] = @Rank WHERE payments.id = @PaymentId", new { PaymentId = employerId, Rank = ranking.Id });
//         connection.Close();


//     }

//     private int CalculatePoints(IEnumerable<PaymentHistoryDto> payments)
//     {
//         int Points = 0;
//         foreach(var payment in payments)
//         {
//             if(payment.PaymentDate < payment.DueDate) Points += 3;
//             else if(payment.PaymentDate < payment.DueDate.AddMonths(3)) Points += 2;
//             else if(payment.PaymentDate > payment.DueDate.AddMonths(3)) 
//             {
//                 if(payment.Status) Points += 1;
//                 else Points -= 3;
//             }
//         }
//         return Points;
//     }

//     private Ranking CalculateStars(IEnumerable<PaymentHistoryDto> payments)
//     {
//         payments = payments.OrderByDescending(a => a.ContributionMonth).ToList();

//         payments = payments.Take(12).ToList();
//         if(payments.All(a => a.Status == true)) return Ranking.Platinum;
        
//         payments = payments.Take(6).ToList();
//         if(payments.All(a => a.Status == true)) return Ranking.Gold;

//         payments = payments.Take(3).ToList();
//         if(payments.All(a => a.Status == true)) return Ranking.Silver;

//         return Ranking.Crawler;
//     }
// }   