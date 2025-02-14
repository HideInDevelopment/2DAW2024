using Actividad3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Actividad3.Infrastructure.Persistence.Configurations;

public class PartnerConfiguration : IEntityTypeConfiguration<Partner>
{
    public void Configure(EntityTypeBuilder<Partner> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedOnAdd();

        builder.Property(g => g.Name).HasMaxLength(150);
        builder.Property(g => g.Age).HasMaxLength(2);
        builder.Property(g => g.TelephoneNumber).HasMaxLength(100);
        builder.Property(g => g.Email).HasMaxLength(100);

        builder.HasIndex(g => g.Id).HasDatabaseName("IX_Partner_Id");
        builder.HasIndex(g => g.Name).HasDatabaseName("IX_Partner_Name");
        
        builder.HasMany(p => p.ColonyPartnerItems)
               .WithOne(cp => cp.Partner)
               .HasForeignKey(cp => cp.PartnerId);
        
        builder.ToTable("Partners", "DWES");
    }
}