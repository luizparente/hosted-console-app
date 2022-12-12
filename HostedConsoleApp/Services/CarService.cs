using HostedConsoleApp.Models;
using HostedConsoleApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostedConsoleApp.Services {
	public class CarService : ICarService {
		public async Task<IEnumerable<Car>> Get() {
			return new List<Car>() {
				new Car() { Make = "BMW", Model = "Z5" },
				new Car() { Make = "Porsche", Model = "Cayman" },
				new Car() { Make = "Lamborghini", Model = "Aventador" },
			};
		}
	}
}
