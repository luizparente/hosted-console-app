using HostedConsoleApp.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace HostedConsoleApp {
	public class Application {
        protected readonly IConfiguration _configuration;
        protected readonly ICarService _carService;

        public Application(IConfiguration configuration, ICarService carService) {
            this._configuration = configuration;
            this._carService = carService;
        }

        public async Task Start() {
            var cars = await this._carService.Get();

            foreach (var car in cars) {
                Console.WriteLine(car);
            }

            string message = this._configuration.GetValue<string>("Setting:Value");
            Console.WriteLine(message);
        }
    }
}
