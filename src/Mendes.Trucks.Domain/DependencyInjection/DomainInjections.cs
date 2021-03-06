using Mendes.Trucks.Domain.Interfaces.Services;
using Mendes.Trucks.Domain.Services;
using Mendes.Trucks.Domain.Services.Trucks;
using Mendes.Trucks.Domain.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Mendes.Trucks.Domain.DependencyInjection
{
	public static class DomainInjections
	{
		public static IServiceCollection DomainDependencies(this IServiceCollection services)
		{
			services.AddScoped<ILogService, LogService>();
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<ITruckService, TruckService>();
			return services;
		}
	}
}
