using MediatR;
using Ratings.Domain.AggregatesModel.EmployerAggregate;

namespace Ratings.Application.Commands.AddPayment;

public class AddPaymentCommandHandler : IRequestHandler<AddPaymentCommand, bool>
{
    private readonly IEmployerRepository _employerRepository;
    public AddPaymentCommandHandler(IEmployerRepository employerRepository)
    {
        _employerRepository = employerRepository;
    }
    public async Task<bool> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
    {
        var employer = await _employerRepository.GetByIdAsync(request.EmployerId);
        if(employer == null) throw new KeyNotFoundException();
        employer.AddPayment(request.Year, request.Month, request.Amount);
        return await _employerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}