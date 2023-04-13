using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ratings.Domain.AggregatesModel.EmployerAggregate;

namespace Ratings.Infrastructure.EntityConfiguration;

public class PaymentStatusEntityTypeConfiguration : IEntityTypeConfiguration<PaymentStatus>
{
    public void Configure(EntityTypeBuilder<PaymentStatus> paymentStatusConfiguration)
    {
        paymentStatusConfiguration.ToTable("payment_status", RatingContext.DEFAULT_SCHEMA);

        paymentStatusConfiguration.HasKey(o => o.Id);

        paymentStatusConfiguration.Property(o => o.Id)
            .HasColumnName("id")
            .HasDefaultValue(1)
            .ValueGeneratedNever()
            .IsRequired();

        paymentStatusConfiguration.Property(o => o.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();
    }
}