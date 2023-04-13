using MediatR;
using Ratings.Domain.AggregatesModel.EmployerAggregate;

namespace Ratings.Application.Commands.MarkPaymentAsPaid;

public class MarkPaymentAsPaidCommandHandler : IRequestHandler<MarkPaymentAsPaidCommand, bool>
{
    private readonly IEmployerRepository _employerRepository;

    public MarkPaymentAsPaidCommandHandler(IEmployerRepository employerRepository)
    {
        _employerRepository = employerRepository;   
    }
    
    public async Task<bool> Handle(MarkPaymentAsPaidCommand request, CancellationToken cancellationToken)
    {
        var employer = await _employerRepository.GetByIdAsync(request.EmployerId);
        if(employer == null) throw new KeyNotFoundException();
        employer.MakePayment(request.PaymentId);
        return await _employerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}