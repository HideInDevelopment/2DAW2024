using Actividad3.Application.Services;
using Actividad3.Domain.Entities;
using Actividad3.Domain.Repositories;
using Actividad3.Domain.Repositories.Contracts;
using Actividad3.Domain.Services;
using Actividad3.Infrastructure.Persistence.Configurations;
using Actividad3.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Actividad3.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //DatabaseContext
        services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DAW")));
        
        // Repositories
        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped<ICatRepository, CatRepository>();
        services.AddScoped<IColonyRepository, ColonyRepository>();
        services.AddScoped<IPartnerRepository, PartnerRepository>();
        
        // Services
        services.AddScoped<ICatService, CatService>();
        services.AddScoped<IColonyService, ColonyService>();
        services.AddScoped<IPartnerService, PartnerService>();
        
        // Mappings
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IMapper, Mapper>();
        
        // Fluent API
        services.AddScoped<IEntityTypeConfiguration<Cat>, CatConfiguration>();
        services.AddScoped<IEntityTypeConfiguration<Colony>, ColonyConfiguration>();
        services.AddScoped<IEntityTypeConfiguration<Partner>, PartnerConfiguration>();
        services.AddScoped<IEntityTypeConfiguration<ColonyPartner>, ColonyPartnerConfiguration>();
        
        return services;
    }
}