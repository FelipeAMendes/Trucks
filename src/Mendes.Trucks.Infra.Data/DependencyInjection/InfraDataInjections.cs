using Mendes.Trucks.Domain;
using Mendes.Trucks.Domain.Interfaces.Repositories;
using Mendes.Trucks.Infra.Data.Contexts;
using Mendes.Trucks.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mendes.Trucks.Infra.Data.DependencyInjection
{
	public static class InfraDataInjections
	{
		public static IServiceCollection InfraDataDependencies(this IServiceCollection services)
		{
			services.AddDbContext<MendesTrucksDbContext>(options =>
				options.UseSqlite(MendesTrucksConfiguration.ConnectionStrings.PrincipalConnection));
			services.AddScoped<DbContext, MendesTrucksDbContext>();
			services.AddScoped<ILogRepository, LogRepository>();
			services.AddScoped<ITruckRepository, TruckRepository>();
			services.AddScoped<IUserRepository, UserRepository>();

			return services;
		}
	}
}
