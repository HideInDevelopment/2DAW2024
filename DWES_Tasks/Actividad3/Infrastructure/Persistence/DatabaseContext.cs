using Actividad3.Domain.Entities;
using Actividad3.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Actividad3.Infrastructure.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    
    public DbSet<Colony> Colonies { get; set; }
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Partner> Partners { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    
}

public class OrderingContextDesignFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configurationRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .Build();
        
        var builder = new DbContextOptionsBuilder<DatabaseContext>();
        
        var connectionString = configurationRoot.GetConnectionString("DAW");
        
        builder.UseSqlServer(
            connectionString,
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.MigrationsHistoryTable("__EFMigrationHistory", "DWES");
            });
        
        return new DatabaseContext(builder.Options);
    }
}