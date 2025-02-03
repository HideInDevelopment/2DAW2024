using Actvidad3.Domain.Entities;
using Actvidad3.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Actvidad3.Infrastructure.Persistence;

public class DatabaseContext : DbContext
{
    private readonly IEnumerable<IEntityConfiguration> _configurations;
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options,
        IEnumerable<IEntityConfiguration> configurations) : base(options)
    {
        _configurations = configurations;
    }
    
    public DbSet<Colony> Colonies { get; set; }
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Partner> Partners { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var configuration in _configurations)
        {
            configuration.Configure(modelBuilder);
        }
        
        base.OnModelCreating(modelBuilder);
    }
    
}

public class OrderingContextDesignFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configurationRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var builder = new DbContextOptionsBuilder<DatabaseContext>();
        
        var connectionString = configurationRoot.GetConnectionString("Database");
        
        builder.UseSqlServer(
            connectionString,
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.MigrationsHistoryTable("__EFMigrationHistory", "ClientMeetingHandler");
            });
        
        return new DatabaseContext(builder.Options);
    }
}