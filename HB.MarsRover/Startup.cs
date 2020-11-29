using HB.MarsRover.Application.Services;
using HB.MarsRover.Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HB.MarsRover
{
    public static class Startup
    {
        public static void ConfigureAppConfiguration(IConfigurationBuilder configurationBuilder)
        {
        }
        public static void ConfigureServices(HostBuilderContext hostBuilderContext, IServiceCollection services)
        {
            services.AddTransient<IRoverService, RoverService>();
            services.AddTransient<IInputValidator, InputValidator>();
        }
    }
}
