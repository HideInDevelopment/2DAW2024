using Microsoft.EntityFrameworkCore;

namespace Actvidad3.Infrastructure.Persistence.Configurations;

public interface IEntityConfiguration
{
    void Configure(ModelBuilder modelBuilder);
}