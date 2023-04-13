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

    public Payment(DateTime ContributionMonth, DateTime DueDate, DateTime PaymentDate, decimal PaidAmount)
    {
        _contributionMonth = ContributionMonth;
        _dueDate = ContributionMonth.AddMonths(1);
        _paymentDate = PaymentDate;
        _paidAmount = PaidAmount;
        _status = false;
    }

    public Payment(DateTime ContributionMonth, DateTime DueDate, DateTime PaymentDate, decimal PaidAmount, bool Status)
    {
        _contributionMonth = ContributionMonth;
        _dueDate = ContributionMonth.AddMonths(1);
        _paymentDate = PaymentDate;
        _paidAmount = PaidAmount;
        _status = Status;
    }

    public void MakePayment()
    {
        _status = true;
    }

}