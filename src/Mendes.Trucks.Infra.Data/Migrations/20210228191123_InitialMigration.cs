using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Mendes.Trucks.Infra.Data.Migrations
{
	public partial class InitialMigration : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
					name: "Log",
					columns: table => new
					{
						Id = table.Column<int>(nullable: false)
									.Annotation("Sqlite:Autoincrement", true),
						Date = table.Column<DateTime>(nullable: false, defaultValueSql: "DATE()"),
						UserIp = table.Column<string>(maxLength: 16, nullable: false),
						Object = table.Column<string>(nullable: true),
						OperationId = table.Column<int>(nullable: false),
						User = table.Column<string>(maxLength: 50, nullable: true),
						Table = table.Column<string>(maxLength: 50, nullable: true),
						Platform = table.Column<string>(nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Log", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "Truck",
					columns: table => new
					{
						Id = table.Column<int>(nullable: false)
									.Annotation("Sqlite:Autoincrement", true),
						TruckModel = table.Column<int>(nullable: false),
						ManufactureYear = table.Column<int>(nullable: false),
						ModelYear = table.Column<int>(nullable: false),
						RegisterDate = table.Column<DateTime>(nullable: false, defaultValueSql: "DATE()")
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Truck", x => x.Id);
					});

			migrationBuilder.CreateTable(
					name: "User",
					columns: table => new
					{
						Id = table.Column<int>(nullable: false)
									.Annotation("Sqlite:Autoincrement", true),
						Name = table.Column<string>(maxLength: 100, nullable: false),
						Cpf = table.Column<string>(maxLength: 11, nullable: false),
						Email = table.Column<string>(maxLength: 100, nullable: false),
						Password = table.Column<string>(maxLength: 64, nullable: false),
						Role = table.Column<string>(maxLength: 50, nullable: false),
						Enabled = table.Column<bool>(nullable: false, defaultValue: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_User", x => x.Id);
					});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
					name: "Log");

			migrationBuilder.DropTable(
					name: "Truck");

			migrationBuilder.DropTable(
					name: "User");
		}
	}
}
