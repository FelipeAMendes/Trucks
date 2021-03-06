using Mendes.Trucks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mendes.Trucks.Infra.Data.EntityConfigurations
{
	public class UserEntityConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
			builder.Property(p => p.Cpf).HasMaxLength(11).IsRequired();
			builder.Property(p => p.Email).HasMaxLength(100).IsRequired();
			builder.Property(p => p.Password).HasMaxLength(64).IsRequired();
			builder.Property(p => p.Role).HasMaxLength(50).IsRequired();
			builder.Property(p => p.Enabled).IsRequired().HasDefaultValue(true);
		}
	}
}
