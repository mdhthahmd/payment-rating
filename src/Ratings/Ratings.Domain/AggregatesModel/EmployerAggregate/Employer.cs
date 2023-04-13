using Ratings.Domain.Events;
using Ratings.Domain.Exceptions;
using Ratings.Domain.SeedWork;

namespace Ratings.Domain.AggregatesModel.EmployerAggregate;

public class Employer : Entity, IAggregateRoot
{
    protected Employer() 
    {
        _payments = new List<Payment>();
    }

    public string Name { get; private set; } = string.Empty;
    public int Points { get; private set; }

    private readonly List<Payment> _payments;
    public IReadOnlyCollection<Payment> Payments => _payments;


    public Ranking Ranking { get; private set; }
    private int _rankingId;

    public void UpdatePointRanking()
    {
        int totalPoints = 0;

        foreach (var payment in _payments)
        {
            if(payment.GetStatus())
            {
                TimeSpan timeDifference = payment.GetPaymentDate() - payment.GetDueDate();
                int monthsDifference = (int)Math.Floor(timeDifference.TotalDays / 30.436875);
                
                if(monthsDifference < 0) totalPoints += 3;
                else if(monthsDifference < 3) totalPoints += 2;
                else if(monthsDifference > 3) totalPoints += 1;
            }
            else
            {
                TimeSpan timeDifference = DateTime.Now - payment.GetDueDate();
                int monthsDifference = (int)Math.Floor(timeDifference.TotalDays / 30.436875);
                if(monthsDifference > 3) totalPoints -= 3;
            }
        }

        this.Points = totalPoints;


        int months = 0;
        var tempPayments = _payments
            .OrderByDescending(a => a.GetContributionMonth())
            .Take(12).ToList();

        foreach(var p in tempPayments)
        {
            if(!p.GetStatus()) break;
            months++;
        }

        if(months >= 12) this._rankingId = 5;
        else if(months >= 6 && months < 12) this._rankingId = 4;
        else if(months >= 3 && months < 6) this._rankingId = 3;
        else this._rankingId = 0;
    }

    public void AddPayment(int contributionYear, int contributionMonth, decimal amount)
    {
        var exists =_payments.Any(a => a.GetContributionMonth().Year == contributionYear 
                && a.GetContributionMonth().Month == contributionMonth);

        if(exists) throw new RatingDomainException("A payment for the month already exists");

        try
        {
            var contributionDate = new DateTime(contributionYear, contributionMonth, 1);
            var newPayment = new Payment(contributionDate, amount);
            _payments.Add(newPayment);
            AddPaymentAddedDomainEvent(this);
        }
        catch(ArgumentOutOfRangeException ex)
        {
            throw new RatingDomainException("invalid contribution date");
        }

    }

    private void AddPaymentAddedDomainEvent(Employer employer)
    {
        this.AddDomainEvent(new PaymentAddedDomainEvent(employer.Id));
    }

      private void AddPaymentMarkedAsPaidDomainEvent(Employer employer)
    {
        this.AddDomainEvent(new PaymentMarkedAsPaidDomainEvent(employer.Id));
    }

    public void MakePayment(int paymentId)
    {
        var paymentMade = _payments.FirstOrDefault(a => a.Id == paymentId);
        if(paymentMade != null)
        {
            paymentMade.MakePayment();
            AddPaymentMarkedAsPaidDomainEvent(this);
        }
    }

}