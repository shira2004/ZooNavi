using Common.Dto;
using Microsoft.Extensions.DependencyInjection;
using Service.Interface;
using Service.Services;
using Service;
using Repository;
using Repository.Repositories;
using Repository.Entities;

public static class ExtensionServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddRepository();
        services.AddScoped<DistanceCalculationService>();
        services.AddScoped<IService<AnimalDto>, AnimalService>();
        services.AddScoped<ICage<CageDto>, CageService>();
        services.AddScoped<IService<ZooDto>, ZooService>();
        services.AddScoped<IService<TicketDto>, TicketService>();
        services.AddScoped<IService<KioskDto>, KioskService>();
        services.AddScoped<IService<UserDto>, UserService>();
        services.AddScoped<IService<RiddleDto>, RiddleService>();

         services.AddScoped<ImageUploadService>();
        services.AddScoped <TokenService>();
        services.AddAutoMapper(typeof(MapperProfile));

  
        return services;
    }
}
