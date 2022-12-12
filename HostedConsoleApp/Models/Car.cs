using System;

namespace HostedConsoleApp.Models {
	public class Car {
		public string CarID { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }

		public Car() {
			this.CarID = Guid.NewGuid().ToString();
		}

		public override string ToString() {
			return $"{this.Make} {this.Model}";
		}
	}
}
