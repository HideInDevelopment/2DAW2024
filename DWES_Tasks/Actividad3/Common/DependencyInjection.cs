using Actvidad3.Application.Profiles;
using Actvidad3.Application.Services;
using Actvidad3.Application.Settings;
using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories;
using Actvidad3.Domain.Repositories.Contracts;
using Actvidad3.Domain.Services;
using Actvidad3.Infrastructure.Persistence;
using Actvidad3.Infrastructure.Persistence.Configurations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Actvidad3.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //DatabaseContext
        services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DWES")));
        
        // Repositories
        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped<ICatRepository, CatRepository>();
        services.AddScoped<IColonyRepository, ColonyRepository>();
        services.AddScoped<IPartnerRepository, PartnerRepository>();
        
        // Services
        services.AddScoped(typeof(IGenericService<,,>), typeof(GenericService<,,>));
        services.AddScoped<ICatService, CatService>();
        services.AddScoped<IColonyService, ColonyService>();
        services.AddScoped<IPartnerService, PartnerService>();
        
        // Mappings
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IMapper, Mapper>();
        
        // Fluent API
        services.AddScoped<IEntityTypeConfiguration<Cat>, CatConfiguration>();
        services.AddScoped<IEntityConfiguration, CatConfiguration>();
        services.AddScoped<IEntityTypeConfiguration<Colony>, ColonyConfiguration>();
        services.AddScoped<IEntityConfiguration, ColonyConfiguration>();
        services.AddScoped<IEntityTypeConfiguration<Partner>, PartnerConfiguration>();
        services.AddScoped<IEntityConfiguration, PartnerConfiguration>();
        
        // AppSettings
        services.Configure<AppSettings>(configuration.GetSection("Settings"));
        
        return services;
    }
}