using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ratings.Domain.AggregatesModel.EmployerAggregate;

namespace Ratings.Infrastructure.EntityConfiguration;
public class RankingEntityTypeConfiguration : IEntityTypeConfiguration<Ranking>
{
    public void Configure(EntityTypeBuilder<Ranking> rankingConfiguration)
    {
        rankingConfiguration.ToTable("ranking", RatingContext.DEFAULT_SCHEMA);

        rankingConfiguration.HasKey(o => o.Id);

        rankingConfiguration.Property(o => o.Id)
            .HasColumnName("id")
            .HasDefaultValue(1)
            .ValueGeneratedNever()
            .IsRequired();

        rankingConfiguration.Property(o => o.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();
    }
}