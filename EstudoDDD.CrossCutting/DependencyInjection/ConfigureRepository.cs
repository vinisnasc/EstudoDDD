using EstudoDDD.Data.Context;
using EstudoDDD.Data.Implementations;
using EstudoDDD.Data.Repository;
using EstudoDDD.Domain.Interfaces;
using EstudoDDD.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;

namespace EstudoDDD.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
            serviceCollection.AddScoped<IUfRepository, UfImplementation>();
            serviceCollection.AddScoped<IMunicipioRepository, MunicipioImplementation>();
            serviceCollection.AddScoped<ICepRepository, CepImplementation>();

            serviceCollection.AddDbContext<MyContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("SQL")));   
        }
    }
}
