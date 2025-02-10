using Microsoft.EntityFrameworkCore;

namespace Actividad3.Infrastructure.Persistence.Configurations;

public interface IEntityConfiguration
{
    void Configure(ModelBuilder modelBuilder);
}