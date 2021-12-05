using EstudoDDD.Domain.Interfaces.Services.Cep;
using EstudoDDD.Domain.Interfaces.Services.Municipio;
using EstudoDDD.Domain.Interfaces.Services.Uf;
using EstudoDDD.Domain.Interfaces.Services.User;
using EstudoDDD.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EstudoDDD.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddTransient<IUfService, UfService>();
            serviceCollection.AddTransient<IMunicipioService, MunicipioService>();
            serviceCollection.AddTransient<ICepService, CepService>();
        }
    }
}
