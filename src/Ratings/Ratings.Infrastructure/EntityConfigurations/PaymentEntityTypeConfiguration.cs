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
        // paymentConfiguration.Ignore(b => b.DomainEvents);

        paymentConfiguration.Property(o => o.Id)
            //.UseHiLo("paymentseq", RatingContext.DEFAULT_SCHEMA);
            .HasColumnName("id");


        paymentConfiguration
            .Property(a => a.EmployerId)
            .HasColumnName("employer_id")
            .IsRequired();


        paymentConfiguration
            .Property(a => a.ContributionMonth)
            .HasColumnName("contribution_month")
            .IsRequired();

        paymentConfiguration
            .Property(a => a.DueDate)
            .HasColumnName("due_date")
            .IsRequired();

        paymentConfiguration
            .Property(a => a.PaymentDate)
            .HasColumnName("payment_date")
            .IsRequired();

        paymentConfiguration
            .Property(a => a.PaidAmount)
            .HasPrecision(16,2)
            .HasColumnName("paid_amount")
            .IsRequired();

        paymentConfiguration
            .Property(a => a.Status)
            .HasColumnName("status")
            .IsRequired();
        
    }
}