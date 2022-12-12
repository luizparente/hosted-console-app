using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostedConsoleApp.Services.Interfaces {
	public interface IService<T> where T: class {
		public Task<IEnumerable<T>> Get();
	}
}
