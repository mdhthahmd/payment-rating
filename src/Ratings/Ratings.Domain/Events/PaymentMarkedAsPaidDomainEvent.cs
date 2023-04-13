using MediatR;

namespace Ratings.Domain.Events;

public class PaymentMarkedAsPaidDomainEvent : INotification
{
    public int EmployerId { get; }

    public PaymentMarkedAsPaidDomainEvent(int EmployerId)
    {
        this.EmployerId = EmployerId;
    }
}