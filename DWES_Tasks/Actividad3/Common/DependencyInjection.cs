using Actividad3.Application.Services;
using Actividad3.Application.Settings;
using Actividad3.Domain.Entities;
using Actividad3.Domain.Repositories;
using Actividad3.Domain.Repositories.Contracts;
using Actividad3.Domain.Services;
using Actividad3.Infrastructure.Persistence.Configurations;
using Actividad3.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CatRepository = Actividad3.Domain.Repositories.CatRepository;
using ColonyRepository = Actividad3.Domain.Repositories.ColonyRepository;
using PartnerRepository = Actividad3.Domain.Repositories.PartnerRepository;
using Repositories_CatRepository = Actividad3.Domain.Repositories.CatRepository;
using Repositories_ColonyRepository = Actividad3.Domain.Repositories.ColonyRepository;
using Repositories_PartnerRepository = Actividad3.Domain.Repositories.PartnerRepository;

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
        services.AddScoped<ICatRepository, Repositories_CatRepository>();
        services.AddScoped<IColonyRepository, Repositories_ColonyRepository>();
        services.AddScoped<IPartnerRepository, Repositories_PartnerRepository>();
        
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
        services.AddScoped<IEntityTypeConfiguration<Colony>, ColonyConfiguration>();
        services.AddScoped<IEntityTypeConfiguration<Partner>, PartnerConfiguration>();
        services.AddScoped<IEntityTypeConfiguration<ColonyPartner>, ColonyPartnerConfiguration>();
        
        // AppSettings
        services.Configure<AppSettings>(configuration.GetSection("Settings"));
        
        return services;
    }
}