using Ratings.Domain.SeedWork;

namespace Ratings.Domain.AggregatesModel.EmployerAggregate;
public class Payment : Entity
{
    private DateTime _contributionMonth;
    private DateTime _dueDate;
    private DateTime _paymentDate;
    private decimal _paidAmount;
    private bool _status;

    protected Payment() { }

    public Payment(DateTime ContributionDate, decimal Amount)
    {

        _contributionMonth = ContributionDate;
        _dueDate = new DateTime(ContributionDate.Year, ContributionDate.Month+1, 15);
        _paymentDate = DateTime.MinValue;
        _paidAmount = Amount;
        _status = false;
    }

    public bool GetStatus() => _status;
    public DateTime GetContributionMonth() => _contributionMonth;
    public DateTime GetDueDate() => _dueDate;
    public DateTime GetPaymentDate() => _paymentDate;
    public void MakePayment()
    {
        _status = true;
        _paymentDate = DateTime.Now;
    }

}