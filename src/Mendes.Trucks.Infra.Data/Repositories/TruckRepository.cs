using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mendes.Trucks.Infra.Data.Repositories
{
	public class TruckRepository : Repository<Truck>, ITruckRepository
	{
		public TruckRepository(DbContext context)
			: base(context)
		{

		}
	}
}
