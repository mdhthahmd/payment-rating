using MediatR;
using Ratings.Domain.AggregatesModel.EmployerAggregate;
using Ratings.Domain.Events;

namespace Ratings.Application.DomainEvents;

public class PaymentAddedDomainEventHandler
    : INotificationHandler<PaymentAddedDomainEvent>
{
    private readonly IEmployerRepository _employerRepository;
    public PaymentAddedDomainEventHandler(IEmployerRepository employerRepository)
    {
        _employerRepository = employerRepository;
    }
    public async Task Handle(PaymentAddedDomainEvent paymentAddedDomainEvent, CancellationToken cancellationToken)
    {
        var employer = await _employerRepository.GetByIdAsync(paymentAddedDomainEvent.EmployerId);
        employer.UpdatePointRanking();
        await _employerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
