﻿// <auto-generated />

using Mendes.Trucks.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace Mendes.Trucks.Infra.Data.Migrations
{
	[DbContext(typeof(MendesTrucksDbContext))]
	partial class MendesTrucksDbContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
					.HasAnnotation("ProductVersion", "3.1.8");

			modelBuilder.Entity("Mendes.Trucks.Domain.Entities.Log", b =>
					{
						b.Property<int>("Id")
											.ValueGeneratedOnAdd()
											.HasColumnType("INTEGER");

						b.Property<DateTime>("Date")
											.ValueGeneratedOnAdd()
											.HasColumnType("TEXT")
											.HasDefaultValueSql("DATE()");

						b.Property<string>("Object")
											.HasColumnType("TEXT");

						b.Property<int>("OperationId")
											.HasColumnType("INTEGER");

						b.Property<string>("Platform")
											.IsRequired()
											.HasColumnType("TEXT");

						b.Property<string>("Table")
											.HasColumnType("TEXT")
											.HasMaxLength(50);

						b.Property<string>("User")
											.HasColumnType("TEXT")
											.HasMaxLength(50);

						b.Property<string>("UserIp")
											.IsRequired()
											.HasColumnType("TEXT")
											.HasMaxLength(16);

						b.HasKey("Id");

						b.ToTable("Log");
					});

			modelBuilder.Entity("Mendes.Trucks.Domain.Entities.Truck", b =>
					{
						b.Property<int>("Id")
											.ValueGeneratedOnAdd()
											.HasColumnType("INTEGER");

						b.Property<int>("ManufactureYear")
											.HasColumnType("INTEGER");

						b.Property<int>("ModelYear")
											.HasColumnType("INTEGER");

						b.Property<DateTime>("RegisterDate")
											.ValueGeneratedOnAdd()
											.HasColumnType("TEXT")
											.HasDefaultValueSql("DATE()");

						b.Property<int>("TruckModel")
											.HasColumnType("INTEGER");

						b.HasKey("Id");

						b.ToTable("Truck");
					});

			modelBuilder.Entity("Mendes.Trucks.Domain.Entities.User", b =>
					{
						b.Property<int>("Id")
											.ValueGeneratedOnAdd()
											.HasColumnType("INTEGER");

						b.Property<string>("Cpf")
											.IsRequired()
											.HasColumnType("TEXT")
											.HasMaxLength(11);

						b.Property<string>("Email")
											.IsRequired()
											.HasColumnType("TEXT")
											.HasMaxLength(100);

						b.Property<bool?>("Enabled")
											.IsRequired()
											.ValueGeneratedOnAdd()
											.HasColumnType("INTEGER")
											.HasDefaultValue(true);

						b.Property<string>("Name")
											.IsRequired()
											.HasColumnType("TEXT")
											.HasMaxLength(100);

						b.Property<string>("Password")
											.IsRequired()
											.HasColumnType("TEXT")
											.HasMaxLength(64);

						b.Property<string>("Role")
											.IsRequired()
											.HasColumnType("TEXT")
											.HasMaxLength(50);

						b.HasKey("Id");

						b.ToTable("User");
					});
#pragma warning restore 612, 618
		}
	}
}
