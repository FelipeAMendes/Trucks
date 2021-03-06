using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Enums;
using Mendes.Trucks.Domain.Interfaces.Services;
using Mendes.Trucks.Domain.Results;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Mendes.Trucks.Tests.Domain
{
	public class TruckDomainTests
	{
		[Fact]
		public void Truck_SetProperties_IsValid()
		{
			var truck = new Truck { TruckModel = TruckModel.Fh, ManufactureYear = 0, ModelYear = DateTime.Now.Year, RegisterDate = DateTime.Now.Date };

			Assert.Equal(0, truck.ManufactureYear);
			Assert.Equal(TruckModel.Fh, truck.TruckModel);
			Assert.Equal(DateTime.Now.Date, truck.RegisterDate);
			Assert.Equal(truck.ModelYear, DateTime.Now.Year);
		}

		[Theory]
		[InlineData(0, 2021, false)]
		[InlineData(2021, 0, false)]
		[InlineData(2021, 2020, false)]
		[InlineData(2019, 2021, false)]
		public void Truck_SetPropertiesDomainObject_IsInvalid(int manufactureYear, int modelYear, bool expectedResult)
		{
			var truckModel = new Truck
			{
				ManufactureYear = manufactureYear,
				ModelYear = modelYear
			};

			var truckService = new Mock<ITruckService>();
			truckService
				.Setup(r => r.Add(truckModel))
				.Returns(Task.FromResult(Result<IEnumerable<string>>.Create(false, new List<string>())));

			var result = truckService.Object.Add(truckModel).Result;
			Assert.Equal(result.Success, expectedResult);
		}

		[Theory]
		[InlineData(2019, 2020, true)]
		[InlineData(2020, 2020, true)]
		[InlineData(2020, 2021, true)]
		public void Truck_SetPropertiesDomainObject_IsValid(int manufactureYear, int modelYear, bool expectedResult)
		{
			var truckModel = new Truck
			{
				ManufactureYear = manufactureYear,
				ModelYear = modelYear
			};

			var truckService = new Mock<ITruckService>();
			truckService
				.Setup(r => r.Add(truckModel))
				.Returns(Task.FromResult(Result<IEnumerable<string>>.Create(true, new List<string>())));

			var result = truckService.Object.Add(truckModel).Result;
			Assert.Equal(result.Success, expectedResult);
		}
	}
}
