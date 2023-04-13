namespace Ratings.Application.Queries;

public class EmployerDropdownItem
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class PendingPaymentDto 
{
    public int Id { get; set; }
    public int EmployerId { get; set; }
    public string Employer { get; set; }
    public int Points { get; set; }
    public int Rank { get; set; }
    public decimal Amount { get; set; }
    public DateTime ContributionMonth { get; set; }
    public DateTime DueDate { get; set; }
}

public class PaymentHistoryDto 
{
    public int Id { get; set; }
    public int EmployerId { get; set; }
    public string Employer { get; set; }
    public int Points { get; set; }
    public int Rank { get; set; }
    public decimal Amount { get; set; }
    public DateTime ContributionMonth { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime PaymentDate { get; set; }
}

public class EmployerDto 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Points { get; set; }
    public int Stars { get; set; }
}

public class DashboardRanking
{
    public List<EmployerDto> Best { get; set; }
    public List<EmployerDto> Worst { get; set; }

}