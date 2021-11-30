using EstudoDDD.Data.Context;
using EstudoDDD.Data.Implementations;
using EstudoDDD.Data.Repository;
using EstudoDDD.Domain.Interfaces;
using EstudoDDD.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EstudoDDD.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();


            serviceCollection.AddDbContext<MyContext>(options => options
                    .UseSqlServer("Integrated Security = SSPI;Persist Security Info=False;Initial Catalog=EstudoDDD;Data Source=DESKTOP-R9JFMSC\\SQLEXPRESS"));

        }
    }
}
