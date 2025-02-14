using Actividad3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Actividad3.Infrastructure.Persistence.Configurations;

public class CatConfiguration : IEntityTypeConfiguration<Cat>
{
    public void Configure(EntityTypeBuilder<Cat> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedOnAdd();

        builder.Property(g => g.Name).HasMaxLength(150);
        builder.Property(g => g.Age).HasMaxLength(2);
        builder.Property(g => g.Race).HasMaxLength(50);
        builder.Property(g => g.Weight).HasMaxLength(5);
        builder.Property(g => g.HealthState);
        builder.Property(g => g.ColonyId);

        builder.HasIndex(g => g.Id).HasDatabaseName("IX_Cat_Id");
        builder.HasIndex(g => g.Name).HasDatabaseName("IX_Cat_Name");
        builder.HasIndex(g => g.Race).HasDatabaseName("IX_Cat_Race");
        
        builder.HasOne(c => c.Colony)
               .WithMany(colony => colony.CatItems)
               .HasForeignKey(c => c.ColonyId)
               .OnDelete(DeleteBehavior.Cascade);
        
        builder.ToTable("Cats", "DWES");
    }
}