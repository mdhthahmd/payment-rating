using MediatR;

namespace Ratings.Domain.Events;

public class PaymentAddedDomainEvent : INotification
{
    public int EmployerId { get; }

    public PaymentAddedDomainEvent(int EmployerId)
    {
        this.EmployerId = EmployerId;
    }
}