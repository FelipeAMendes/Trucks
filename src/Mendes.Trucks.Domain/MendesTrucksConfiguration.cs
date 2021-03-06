using System;
using Microsoft.Extensions.Configuration;

namespace Mendes.Trucks.Domain
{
	public static class MendesTrucksConfiguration
	{
		public static void Configure(IConfiguration configuration)
		{
			if (configuration is null)
				throw new InvalidOperationException("Configuration not initialized");

			AddConfigurations(configuration);
		}

		private static void AddConfigurations(IConfiguration configuration)
		{
			ConnectionStrings = new ConnStringsConfig
			{
				PrincipalConnection = configuration
					.GetSection($"{ConnStringsConfig.ConnectionStrings}:{nameof(ConnStringsConfig.PrincipalConnection)}")
					?.Value
			};

			Jwt = new JwtConfig
			{
				Secret = configuration.GetSection($"{JwtConfig.Jwt}:{nameof(JwtConfig.Secret)}")?.Value,
				CookieName = configuration.GetSection($"{JwtConfig.Jwt}:{nameof(JwtConfig.CookieName)}")?.Value
			};

			UseAuth = configuration.GetValue<bool>($"{nameof(UseAuth)}");
		}

		public static ConnStringsConfig ConnectionStrings;
		public static JwtConfig Jwt;
		public static bool UseAuth;
	}

	public class ConnStringsConfig
	{
		public const string ConnectionStrings = "ConnectionStrings";
		public string PrincipalConnection { get; set; }
	}

	public class JwtConfig
	{
		public const string Jwt = "Jwt";
		public string Secret { get; set; }
		public string CookieName { get; set; }
	}
}
