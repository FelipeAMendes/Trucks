using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Mendes.Trucks.Infra.Data.Contexts
{
	public class MendesTrucksDbContext : DbContext
	{
		public MendesTrucksDbContext(DbContextOptions<MendesTrucksDbContext> options)
			: base(options)
		{
		}

		public DbSet<Log> Log { get; set; }
		public DbSet<User> User { get; set; }
		public DbSet<Truck> Truck { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new LogEntityConfiguration());
			modelBuilder.ApplyConfiguration(new TruckEntityConfiguration());
			modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
		}
	}
}
