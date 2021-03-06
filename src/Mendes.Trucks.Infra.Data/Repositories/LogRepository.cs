using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mendes.Trucks.Infra.Data.Repositories
{
	public class LogRepository : Repository<Log>, ILogRepository
	{
		public LogRepository(DbContext context)
			: base(context)
		{
		}
	}
}
