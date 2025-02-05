using System.Text.Json;
using Actvidad3.Common;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Setup environment specific .config files
builder.Configuration.AddJsonFile(
    $"appsettings.{builder.Environment.EnvironmentName}.json",
    optional: true
);

//Dependency Injection
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services
       .AddControllers()
       .AddXmlSerializerFormatters()
       .AddJsonOptions(options =>
       {
           options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
       });

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(swg =>
{
    swg.SwaggerDoc("v2", new OpenApiInfo { Title = "API", Version = "v2" });
});

builder.Services.AddMvc();

builder.Services.AddCors(options =>
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