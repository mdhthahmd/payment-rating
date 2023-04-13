namespace Ratings.Api.Models;

public class PaymentListDto
{
    public int Id { get; set; }
    public DateTime ContributionMonth { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal PaidAmount { get; set; }
    public string Status { get; set; }
}