using MediatR;

namespace Ratings.Application.Commands.AddPayment;

public class AddPaymentCommand : IRequest<bool>
{
    public int EmployerId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal Amount { get; set; }
}