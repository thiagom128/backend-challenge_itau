using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IEngineValidPasswordService, EngineValidPasswordService>();
            serviceCollection.AddTransient<IValidPasswordService, ValidPasswordService>();

        }

    }
}
