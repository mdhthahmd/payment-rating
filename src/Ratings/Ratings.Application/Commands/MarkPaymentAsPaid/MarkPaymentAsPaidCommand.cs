using MediatR;

namespace Ratings.Application.Commands.MarkPaymentAsPaid;

public class MarkPaymentAsPaidCommand : IRequest<bool>
{
    public int EmployerId { get; set;  }
    public int PaymentId { get; set; }
}