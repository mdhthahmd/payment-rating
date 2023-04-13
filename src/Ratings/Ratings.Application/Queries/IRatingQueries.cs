namespace Ratings.Application.Queries;

public interface IRatingQueries
{
    Task<int> CountPaymentsAsync();
    Task<int> CountPendingPaymentsAsync();
    Task<int> CountEmployersAsync();
    Task<List<EmployerDropdownItem>> GetEmployersForDropdownAsync();
    Task<List<PaymentHistoryDto>> GetPaginatedPaymentsAsync(int pageSize, int pageNo);
    Task<List<PendingPaymentDto>> GetPaginatedPendingPaymentsAsync(int pageSize, int pageNo);
    Task<List<EmployerDto>> GetPaginatedEmployersAsync(int pageSize, int pageNo);
    Task<List<EmployerDto>> GetHighestRankedEmployers(int Number);
    Task<List<EmployerDto>> GetLowesttRankedEmployers(int Number);

    Task AddPayment(int EmployerId, int Year, int Month, decimal Amount);
    
}