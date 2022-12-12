using HostedConsoleApp.Services;
using HostedConsoleApp.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace HostedConsoleApp {
	public class Program {
		static void Main(string[] args) {
			IHostBuilder hostBuilder = CreateHostBuilder(args);
			bool isHosted = true;

			if (isHosted) {
				var host = hostBuilder.Build();
				host.RunAsync().Wait();
			}
			else {
				var serviceScope = hostBuilder.ConfigureServices(services => {
					try {
						using (var provider = services.BuildServiceProvider()) {
							Application app = provider.GetService<Application>();
							app.Start().Wait();
						}
					}
					catch (Exception e) {
						Console.WriteLine(e);
					}
				});

				hostBuilder.Build();
			}
		}

		public static IHostBuilder CreateHostBuilder(string[] args) {
			return Host.CreateDefaultBuilder(args)
				.ConfigureServices((hostContext, services) => {
					services.AddHostedService<HostedApplication>();
					services.Configure<ConsoleLifetimeOptions>(opts => opts.SuppressStatusMessages = false);

					services.AddTransient<Application>();

					RegisterServices(services);
				})
				.ConfigureAppConfiguration((hostingContext, configuration) => {
					IHostEnvironment env = hostingContext.HostingEnvironment;
					configuration.Sources.Clear();
					configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

					IConfigurationRoot configurationRoot = configuration.Build();
				});
		}

		public static void RegisterServices(IServiceCollection services) {
			services.AddSingleton<ICarService, CarService>();
		}
	}
}
