namespace DataGenerator;
public class Payment
{

    // employer_id, contribution_month, payment_date, due_date, paid_amount, payment_status 
    public Guid Id { get; set; }
    public Guid EmployerId { get; set; }
    public DateTime ContributionMonth { get; set;}
    public DateTime PaymentDate { get; set; }
    public DateTime DueDate { get; set; }
    public int PaidAmount { get; set; }
    public bool PaymentStatus { get; set; }

}