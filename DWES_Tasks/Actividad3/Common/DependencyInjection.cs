using Actvidad3.Application.Profiles;
using Actvidad3.Application.Services;
using Actvidad3.Application.Settings;
using Actvidad3.Common.Functions;
using Actvidad3.Common.Storage.Factories;
using Actvidad3.Common.Storage.Repositories;
using Actvidad3.Common.Storage.Services;
using Actvidad3.Domain.Entities;
using Actvidad3.Domain.Repositories;
using Actvidad3.Domain.Repositories.Contracts;
using Actvidad3.Domain.Services;
using Actvidad3.Infrastructure.Persistence;
using Actvidad3.Infrastructure.Persistence.Configurations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CatRepository = Actvidad3.Domain.Repositories.CatRepository;
using ColonyRepository = Actvidad3.Domain.Repositories.ColonyRepository;
using PartnerRepository = Actvidad3.Domain.Repositories.PartnerRepository;

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
        
        // Manager services
        services.AddScoped<EntityServiceManager<Guid, Cat>>();
        services.AddScoped<EntityServiceManager<Guid, Colony>>();
        services.AddScoped<EntityServiceManager<Guid, Partner>>();
        services.AddScoped<EntityServiceManager<Guid, ColonyPartner>>();
        
        // Storage repositories
        services.AddScoped<ICatRepository>(provider =>
        {
            var catManager = provider.GetRequiredService<EntityServiceManager<Guid, Cat>>();
            var catPath = GenericFunctions.GetSpecificPath("Database", "CatDB") ?? "";
            var storedCatItems = catManager.FillWithItems(catPath) ?? Array.Empty<Cat>();

            return new StorageCatRepository(catPath, storedCatItems, catManager);
        });
        
        services.AddScoped<IColonyRepository>(provider =>
        {
            var colonyManager = provider.GetRequiredService<EntityServiceManager<Guid, Colony>>();
            var colonyPath = GenericFunctions.GetSpecificPath("Database", "ColonyDB") ?? "";
            var storedColonyItems = colonyManager.FillWithItems(colonyPath) ?? Array.Empty<Colony>();

            return new StorageColonyRepository(colonyPath, storedColonyItems, colonyManager);
        });
        
        services.AddScoped<IPartnerRepository>(provider =>
        {
            var partnerManager = provider.GetRequiredService<EntityServiceManager<Guid, Partner>>();
            var partnerPath = GenericFunctions.GetSpecificPath("Database", "PartnerDB") ?? "";
            var storedPartnerItems = partnerManager.FillWithItems(partnerPath) ?? Array.Empty<Partner>();

            return new StoragePartnerRepository(partnerPath, storedPartnerItems, partnerManager);
        });
        
        services.AddScoped<IColonyPartnerRepository>(provider =>
        {
            var colonyPartnerManager = provider.GetRequiredService<EntityServiceManager<Guid, ColonyPartner>>();
            var colonyPartnerPath = GenericFunctions.GetSpecificPath("Database", "ColonyPartnerDB") ?? "";
            var storedColonyPartnerItems = colonyPartnerManager.FillWithItems(colonyPartnerPath) ?? Array.Empty<ColonyPartner>();

            return new StorageColonyPartnerRepository(colonyPartnerPath, storedColonyPartnerItems, colonyPartnerManager);
        });
        
        // Dynamic storage
        services.AddSingleton<IStorageRepositoryFactory, StorageRepositoryFactory>();
        services.AddScoped<DynamicStorage>();
        
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
        services.AddScoped<IEntityTypeConfiguration<ColonyPartner>, ColonyPartnerConfiguration>();
        services.AddScoped<IEntityConfiguration, ColonyPartnerConfiguration>();
        
        // AppSettings
        services.Configure<AppSettings>(configuration.GetSection("Settings"));
        
        return services;
    }
}