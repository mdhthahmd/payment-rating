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
            .UseHiLo("paymentseq", RatingContext.DEFAULT_SCHEMA);

        paymentConfiguration.Property(a => a.Id)
            .HasColumnName("id");

        paymentConfiguration
            .Property<int>("EmployerId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("employer_id")
            .IsRequired();


        paymentConfiguration
            .Property<DateTime>("_contributionMonth")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("contribution_month")
            .IsRequired();

        paymentConfiguration
            .Property<DateTime>("_dueDate")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("due_date")
            .IsRequired();

        paymentConfiguration
            .Property<DateTime>("_paymentDate")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("payment_date")
            .IsRequired();

        paymentConfiguration
            .Property<decimal>("_paidAmount")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("paid_amount")
            .IsRequired();

        paymentConfiguration
            .Property<bool>("_status")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("status")
            .IsRequired();
        
    }
}