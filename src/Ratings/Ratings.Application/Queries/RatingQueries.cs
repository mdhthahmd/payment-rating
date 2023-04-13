// SELECT rating.employers.id, rating.employers.name FROM rating.employers;



using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Ratings.Application.Queries;

public class RatingQueries : IRatingQueries
{
    private readonly IConfiguration _config;

    public RatingQueries(IConfiguration config)
    {
        _config = config;
    }

    public async Task<int> CountPaymentsAsync()
    {
        using var connection = new SqlConnection(_config["ConnectionString"]);
        connection.Open();
        var count = await connection.QueryFirstAsync<int>("SELECT COUNT(*) FROM rating.payments as p WHERE p.[status] = 1");
        return count;
    }

        public async Task<int> CountPendingPaymentsAsync()
    {
        using var connection = new SqlConnection(_config["ConnectionString"]);
        connection.Open();
        var count = await connection.QueryFirstAsync<int>("SELECT COUNT(*) FROM rating.payments as p WHERE p.[status] = 0");
        return count;
    }

    public async Task<int> CountEmployersAsync()
    {
        using var connection = new SqlConnection(_config["ConnectionString"]);
        connection.Open();
        var count = await connection.QueryFirstAsync<int>("SELECT COUNT(*) FROM rating.employers;");
        return count;
    }

    public async Task<List<EmployerDropdownItem>> GetEmployersForDropdownAsync()
    {
        using var connection = new SqlConnection(_config["ConnectionString"]);
        connection.Open();
        var dropdownItems = await connection.QueryAsync<EmployerDropdownItem>
            ("SELECT e.id, e.name FROM rating.employers as e ORDER BY e.name");
        return dropdownItems.AsList();
    }

    public async Task<List<PaymentHistoryDto>> GetPaginatedPaymentsAsync(int pageSize, int pageNo)
    {
        using var connection = new SqlConnection(_config["ConnectionString"]);
        connection.Open();
        var payments = await connection.QueryAsync<PaymentHistoryDto>
            (@"SELECT 
                p.id,
                p.employer_id as EmployerId,
                e.name as Employer,
                e.ranking_id as Rank,
                e.points,
                p.paid_amount as Amount,
                p.contribution_month as ContributionMonth,
                p.payment_date as PaymentDate,
                p.due_date as DueDate
                FROM rating.payments as p
                INNER JOIN rating.employers as e ON p.employer_id = e.id
                WHERE p.[status] = 1
                ORDER BY p.payment_date DESC
                OFFSET (@pageNo-1)* @pageSize ROWS FETCH NEXT @pageSize ROWS ONLY", new { pageNo = pageNo, pageSize = pageSize });
        return payments.AsList();
    }

    public async Task<List<PendingPaymentDto>> GetPaginatedPendingPaymentsAsync(int pageSize, int pageNo)
    {
        using var connection = new SqlConnection(_config["ConnectionString"]);
        connection.Open();
        var payments = await connection.QueryAsync<PendingPaymentDto>
            (@"SELECT 
                p.id,
                p.employer_id as EmployerId,
                e.name as Employer,
                e.ranking_id as Rank,
                e.points,
                p.paid_amount as Amount,
                p.contribution_month as ContributionMonth,
                p.due_date as DueDate
                FROM rating.payments as p
                INNER JOIN rating.employers as e ON p.employer_id = e.id
                WHERE p.[status] = 0
                ORDER BY p.contribution_month ASC
                OFFSET (@pageNo-1)* @pageSize ROWS FETCH NEXT @pageSize ROWS ONLY", new { pageNo = pageNo, pageSize = pageSize });
        return payments.AsList();
    }

    public async Task<List<EmployerDto>> GetPaginatedEmployersAsync(int pageSize, int pageNo)
    {
        using var connection = new SqlConnection(_config["ConnectionString"]);
        connection.Open();
        var employers = await connection.QueryAsync<EmployerDto>
            (@"SELECT
                e.id,
                e.name,
                e.points,
                e.ranking_id as Stars
            FROM rating.employers as e
            ORDER BY  e.points DESC 
            OFFSET (@pageNo-1)* @pageSize ROWS FETCH NEXT @pageSize ROWS ONLY", new { pageNo = pageNo, pageSize = pageSize });
        return employers.AsList();
    }

    public async Task<List<EmployerDto>> GetHighestRankedEmployers(int Number )
    {
        using var connection = new SqlConnection(_config["ConnectionString"]);
        connection.Open();
        var employers = await connection.QueryAsync<EmployerDto>
            (@"SELECT 
                e.id,
                e.name,
                e.points,
                e.ranking_id as stars
            FROM rating.employers as e ORDER BY e.points DESC OFFSET 0 ROWS FETCH NEXT @Number ROWS ONLY", new { Number = Number });
        return employers.AsList();
    }

    public async Task<List<EmployerDto>> GetLowesttRankedEmployers(int Number)
    {
        using var connection = new SqlConnection(_config["ConnectionString"]);
        connection.Open();
        var employers = await connection.QueryAsync<EmployerDto>
            (@"SELECT
                e.id,
                e.name,
                e.points,
                e.ranking_id as stars
            FROM rating.employers as e ORDER BY e.points ASC OFFSET 0 ROWS FETCH NEXT @Number ROWS ONLY", new { Number = Number });
        return employers.AsList();
    }

    public Task AddPayment(int EmployerId, int Year, int Month, decimal Amount)
    {
        // using var connection = new SqlConnection(_config["ConnectionString"]);
        // connection.Open();
        // var employers =  connection.Query();

        return Task.CompletedTask;
    }
}