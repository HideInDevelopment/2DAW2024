using Actvidad3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Actvidad3.Infrastructure.Persistence.Configurations;

public class ColonyPartnerConfiguration : IEntityConfiguration, IEntityTypeConfiguration<ColonyPartner>
{
    public void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(this);
    }

    public void Configure(EntityTypeBuilder<ColonyPartner> builder)
    {
        builder.HasKey(cp => cp.Id);

        builder.HasOne(cp => cp.Colony)
               .WithMany(c => c.ColonyPartnerItems)
               .HasForeignKey(cp => cp.ColonyId);

        builder.HasOne(cp => cp.Partner)
            .WithMany(p => p.ColonyPartnerItems)
            .HasForeignKey(cp => cp.PartnerId);
    }
}