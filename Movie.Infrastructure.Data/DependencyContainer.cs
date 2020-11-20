using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Movie.Application.Interfaces;
using Movie.Application.Services;
using Movie.Domain.Interfaces;
using Movie.Infraestructure.IoC.Repositories;

namespace Movie.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //CleanArchitecture.Application
            services.AddScoped<IMoviesService, MoviesService>();
            services.AddScoped<IDirectorsService, DirectorsService>();

            //CleanArchitecture.Domain.Interfaces | CleanArchitecture.Infra.Data.Repositories
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IDirectorsRepository, DirectorsRepositories>();
        }
    }
}
