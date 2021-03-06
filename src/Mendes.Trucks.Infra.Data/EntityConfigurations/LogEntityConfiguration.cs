using Mendes.Trucks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mendes.Trucks.Infra.Data.EntityConfigurations
{
	public class LogEntityConfiguration : IEntityTypeConfiguration<Log>
	{
		public void Configure(EntityTypeBuilder<Log> builder)
		{
			builder.HasKey(p => p.Id);
			builder.Property(p => p.UserIp).IsRequired().HasMaxLength(16);
			builder.Property(p => p.Date).IsRequired().HasDefaultValueSql("DATE()");
			builder.Property(p => p.Object);
			builder.Property(p => p.OperationId).IsRequired();
			builder.Property(p => p.User).HasMaxLength(50);
			builder.Property(p => p.Table).HasMaxLength(50);
			builder.Property(p => p.Platform).IsRequired();
		}
	}
}
