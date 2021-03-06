using Mendes.Trucks.Application.ViewModels.Trucks;
using Mendes.Trucks.Domain.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mendes.Trucks.Application.Interfaces
{
	public interface ITruckAppService
	{
		Task<TruckViewModel> Find(int id);

		Task<IEnumerable<TruckListViewModel>> List();

		Task<Result<TruckViewModel>> Add(TruckViewModel entity);
		Task<Result<TruckViewModel>> Edit(TruckViewModel entity);
		Task<Result<TruckViewModel>> Delete(int id);

		TruckViewModel CreateViewModel();
	}
}
