using AutoMapper;
using Mendes.Trucks.Application.AutoMapper;
using Mendes.Trucks.Application.DependencyInjection;
using Mendes.Trucks.Domain;
using Mendes.Trucks.Domain.DependencyInjection;
using Mendes.Trucks.Infra.Data.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace Mendes.Trucks.Infra.IoC
{
	public static class Injections
	{
		public static IServiceCollection InjectMendesTrucksDependencies(this IServiceCollection services)
		{
			services.InfraDataDependencies();
			services.DomainDependencies();
			services.ApplicationDependencies();
			return services;
		}

		public static IServiceCollection InjectAutoMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(AutoMapperConfiguration));
			var mapperConfiguration = AutoMapperConfiguration.RegisterMappings();
			var imapper = mapperConfiguration.CreateMapper();
			services.AddSingleton(imapper);
			return services;
		}

		public static IServiceCollection InjectAuthentication(this IServiceCollection services)
		{
			var key = Encoding.ASCII.GetBytes(MendesTrucksConfiguration.Jwt.Secret);
			services.AddAuthentication(a =>
			{
				a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(j =>
			{
				j.RequireHttpsMetadata = false;
				j.SaveToken = true;
				j.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
				j.Events = new JwtBearerEvents
				{
					OnMessageReceived = context =>
					{
						context.Token = context.Request.Cookies[MendesTrucksConfiguration.Jwt.CookieName];
						return Task.CompletedTask;
					}
				};
			});
			return services;
		}
	}
}
