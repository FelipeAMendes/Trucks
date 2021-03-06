using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mendes.Trucks.Domain.Interfaces.Services
{
	public interface ITruckService
	{
		Task<Result<IEnumerable<string>>> Add(Truck truck);
		Task<Result<IEnumerable<string>>> Edit(Truck truck);
	}
}
