using HB.MarsRover.Application.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace HB.MarsRover
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Build and run RoverService for main inputs and calculations.
            CreateHostBuilder(args).Build().Services.GetService<IRoverService>().InitilazeInputsAndCalculate();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(Startup.ConfigureServices)
                .ConfigureAppConfiguration(Startup.ConfigureAppConfiguration);
    }
}
