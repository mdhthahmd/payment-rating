namespace DataGenerator;

public class Employer
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<Payment> Payments { get; set; }
}
