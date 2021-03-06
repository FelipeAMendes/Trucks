using Mendes.Trucks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mendes.Trucks.Infra.Data.EntityConfigurations
{
	public class TruckEntityConfiguration : IEntityTypeConfiguration<Truck>
	{
		public void Configure(EntityTypeBuilder<Truck> builder)
		{
			builder.HasKey(p => p.Id);
			builder.Property(p => p.TruckModel).IsRequired();
			builder.Property(p => p.ManufactureYear).IsRequired();
			builder.Property(p => p.RegisterDate).IsRequired().HasDefaultValueSql("DATE()");
		}
	}
}
