using System.Text.Json;
using Actividad2.Domain.Dto;
using Actividad2.Domain.Entity;
using Actividad2.Domain.Generic.Implementation;
using Actividad2.Domain.Generic.Interface;
using Actividad2.Domain.Persistence;
using Actividad2.Domain.Repository;
using Actividad2.Domain.Service;
using AutoMapper;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(
    $"appsettings.{builder.Environment.EnvironmentName}.json",
    optional: true
);

IServiceCollection services = builder.Services;

services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DWES"));
    opt.UseLazyLoadingProxies(false);
});

services.AddRouting(options => options.LowercaseUrls = true);

services
    .AddControllers()
    .AddXmlSerializerFormatters()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
    
services.AddAuthorization();

services.AddSwaggerGen(swg =>
{
    swg.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
});

services.AddMvc();

services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowAnyOrigin",
        builder =>
            builder
                .WithOrigins("http://localhost")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
    );
});

services.AddResponseCompression();

services.AddResponseCompression(options =>
{
    options.Providers.Add<GzipCompressionProvider>();
    options.EnableForHttps = true;
});

//Inyeccion de dependencias
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddScoped<IMapper, Mapper>();
services.AddScoped<DbContext, DatabaseContext>();
services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
services.AddScoped<IEntityRepository<Guid, Cat>, CatRepository>();
services.AddScoped<IEntityService<Guid, CatDto>, CatService>();

var webApp = builder.Build();

webApp.UseResponseCompression();

webApp.UseHttpsRedirection();

webApp.UseRouting();

webApp.UseCors("AllowAnyOrigin");

webApp.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }
    await next();
});

webApp.UseSwagger();
webApp.UseSwaggerUI();

webApp.MapControllers();

webApp.Run();