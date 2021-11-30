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
        }
    }
}
