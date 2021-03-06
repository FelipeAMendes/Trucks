using Mendes.Trucks.Application.AppService;
using Mendes.Trucks.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Mendes.Trucks.Application.DependencyInjection
{
	public static class ApplicationInjections
	{
		public static IServiceCollection ApplicationDependencies(this IServiceCollection services)
		{
			services.AddScoped<ITruckAppService, TruckAppService>();
			services.AddScoped<IUserAppService, UserAppService>();
			return services;
		}
	}
}
