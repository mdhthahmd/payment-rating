namespace Ratings.Api.Models;

public class AddPaymentDto
{
    public int EmployerId { get; set; }
    public decimal Amount { get; set; }
}