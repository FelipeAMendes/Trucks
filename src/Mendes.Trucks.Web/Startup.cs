using Mendes.Trucks.Domain;
using Mendes.Trucks.Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using System.IO.Compression;
using System.Linq;

namespace Mendes.Trucks.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		private IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			MendesTrucksConfiguration.Configure(Configuration);
			services.AddControllersWithViews();
			services.AddHttpContextAccessor();

			services.AddResponseCompression(options =>
			{
				options.EnableForHttps = true;
				options.Providers.Add<GzipCompressionProvider>();
				options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
				{
					"application/json",
					"text/json",
					"image/png",
					"image/x-icon",
					"image/svg+xml",
					"application/x-font-ttf"
				});
			});

			services.Configure<GzipCompressionProviderOptions>(opt => opt.Level = CompressionLevel.Optimal);
			services.InjectMendesTrucksDependencies();
			services.InjectAutoMapper();
			services.InjectAuthentication();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.Use(async (context, next) =>
			{
				context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
				context.Response.Headers.Add("X-Content-Type-Options", "NOSNIFF");
				context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
				await next();
			});

			//app.UseStatusCodePagesWithReExecute("/error/{0}.html");
			app.UseResponseBuffering();
			app.UseResponseCompression();
			app.UseStaticFiles(new StaticFileOptions
			{
				OnPrepareResponse = ctx => { ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=86400"; }
			});

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
