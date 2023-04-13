using Ratings.Domain.SeedWork;

namespace Ratings.Domain.AggregatesModel.EmployerAggregate;
public class Payment // : Entity
{
    public int Id { get; set; }
    public int EmployerId { get; set; }
    public  DateTime ContributionMonth { get; set; }
    public DateTime DueDate { get; set;}
    public DateTime PaymentDate { get; set;}
    public decimal PaidAmount { get; set; }
    public bool Status { get; set; }

    protected Payment() { }

    public Payment(DateTime ContributionMonth, DateTime DueDate, DateTime PaymentDate, decimal PaidAmount)
    {
        this.ContributionMonth = ContributionMonth;
        this.DueDate = ContributionMonth.AddMonths(1);
        this.PaymentDate = PaymentDate;
        this.PaidAmount = PaidAmount;
        this.Status = false;
    }

    public Payment(DateTime ContributionMonth, DateTime DueDate, DateTime PaymentDate, decimal PaidAmount, bool Status)
    {
        this.ContributionMonth = ContributionMonth;
        this.DueDate = ContributionMonth.AddMonths(1);
        this.PaymentDate = PaymentDate;
        this.PaidAmount = PaidAmount;
        this.Status = Status;
    }

    public void MakePayment()
    {
        Status = true;
    }

}