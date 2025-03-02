using Actividad3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Actividad3.Infrastructure.Persistence.Configurations;

public class ColonyConfiguration : IEntityTypeConfiguration<Colony>
{
    public void Configure(EntityTypeBuilder<Colony> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedOnAdd();

        builder.Property(g => g.Name).HasMaxLength(150);
        builder.Property(g => g.Location).HasMaxLength(50);
        builder.Property(g => g.TelephoneNumber).HasMaxLength(10);
        builder.Property(g => g.MobileNumber).HasMaxLength(10);
        builder.Property(g => g.Description).HasMaxLength(200);
        builder.Property(g => g.Image).HasMaxLength(200);

        builder.HasIndex(g => g.Id).HasDatabaseName("IX_Colony_Id");
        builder.HasIndex(g => g.Name).HasDatabaseName("IX_Colony_Name");
        
        builder.HasMany(c => c.CatItems)
               .WithOne(cat => cat.Colony)
               .HasForeignKey(cat => cat.ColonyId);
        
        builder.HasMany(c => c.ColonyPartnerItems)
               .WithOne(cp => cp.Colony)
               .HasForeignKey(cp => cp.ColonyId);
        
        builder.ToTable("Colonies", "DWES");
    }
}