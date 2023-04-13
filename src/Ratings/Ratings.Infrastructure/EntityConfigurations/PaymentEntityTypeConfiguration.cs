using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ratings.Domain.AggregatesModel.EmployerAggregate;

namespace Ratings.Infrastructure.EntityConfiguration;

public class PaymentEntityTypeConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> paymentConfiguration)
    {

        paymentConfiguration.ToTable("payments", RatingContext.DEFAULT_SCHEMA);

        paymentConfiguration.HasKey(o => o.Id);
        
        paymentConfiguration.Ignore(b => b.DomainEvents);

        paymentConfiguration.Property(o => o.Id)
            .HasColumnName("id")
            .UseHiLo("paymentseq", RatingContext.DEFAULT_SCHEMA);
            

        paymentConfiguration
            .Property<int>("EmployerId")
            .HasColumnName("employer_id")
            .IsRequired();

        paymentConfiguration
            .Property<DateTime>("_contributionMonth")
            .HasColumnName("contribution_month")
            .IsRequired();

        paymentConfiguration
            .Property<DateTime>("_dueDate")
            .HasColumnName("due_date")
            .IsRequired();

        paymentConfiguration
            .Property<DateTime>("_paymentDate")
            .HasColumnName("payment_date")
            .IsRequired();

        paymentConfiguration
            .Property<decimal>("_paidAmount")
            .HasPrecision(16,2)
            .HasColumnName("paid_amount")
            .IsRequired();

        paymentConfiguration
            .Property<bool>("_status")
            .HasColumnName("status")
            .IsRequired();
        
    }
}