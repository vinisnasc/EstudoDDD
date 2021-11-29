using EstudoDDD.Data.Context;
using EstudoDDD.Data.Repository;
using EstudoDDD.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDDD.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));


            serviceCollection.AddDbContext<MyContext>(options => options
                    .UseSqlServer("Server = DESKTOP - R9JFMSC\\SQLEXPRESS; Database = EstudoDDD; Trusted_Connection = True; MultipleActiveResultSets = true"));

        }
    }
}
