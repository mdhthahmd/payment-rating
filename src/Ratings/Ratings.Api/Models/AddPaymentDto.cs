namespace Ratings.Api.Models;

public class AddPaymentDto
{
    public int EmployerId { get; set; }
    public DateTime ContributionDate { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public bool Status { get; set; }
}