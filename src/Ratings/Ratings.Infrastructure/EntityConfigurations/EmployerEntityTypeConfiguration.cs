using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ratings.Domain.AggregatesModel.EmployerAggregate;

namespace Ratings.Infrastructure.EntityConfiguration;

public class EmployerEntityTypeConfiguration : IEntityTypeConfiguration<Employer>
{
    public void Configure(EntityTypeBuilder<Employer> employerConfiguration)
    {
        employerConfiguration.ToTable("employers", RatingContext.DEFAULT_SCHEMA);

        employerConfiguration.HasKey(o => o.Id);

        employerConfiguration.Ignore(b => b.DomainEvents);

        employerConfiguration.Property(o => o.Id)
            //.UseIdentityColumn();
            .UseHiLo("employerseq", RatingContext.DEFAULT_SCHEMA)
            .HasColumnName("id");

        employerConfiguration.Property(a => a.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();

        employerConfiguration.Property(a => a.Points)
            .HasColumnName("points")
            .IsRequired();

        employerConfiguration
            .Property<int>("_rankingId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("ranking_id")
            .IsRequired();

        employerConfiguration.HasOne(o => o.Ranking)
            .WithMany()
            // .HasForeignKey("OrderStatusId");
            .HasForeignKey("_rankingId");

        var navigation = employerConfiguration.Metadata.FindNavigation(nameof(Employer.Payments));

        // DDD Patterns comment:
        //Set as field (New since EF 1.1) to access the OrderItem collection property through its field
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

       

        
    }
}