using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HostedConsoleApp {
	public class HostedApplication : IHostedService {
		private readonly Application _app;

		public HostedApplication(Application app) {
			this._app = app;
		}

		public async Task StartAsync(CancellationToken cancellationToken) {
			Console.WriteLine("Starting app...");

			await this._app.Start();
		}

		public async Task StopAsync(CancellationToken cancellationToken) {
			Console.WriteLine("App closed.");
		}
	}
}
