using Microsoft.Extensions.DependencyInjection;
using Repository.Entities;
using Repository.Interface;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
           
            services.AddScoped<IRepository<Animal> , AnimalRepository>();
            services.AddScoped<IRepository<Cage>, CageRepository>();
            services.AddScoped<IRepository<Kiosk>, KioskRepository>();
            services.AddScoped<IRepository<Ticket>, TicketRepository>();
            services.AddScoped<IRepository<Zoo>, ZooRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Riddle>, RiddleRepository>();




            return services;
        }
    }
}
