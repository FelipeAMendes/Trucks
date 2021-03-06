using Mendes.Trucks.Application.Interfaces;
using Mendes.Trucks.Application.ViewModels.Trucks;
using Mendes.Trucks.Domain.Enums;
using Mendes.Trucks.Domain.Results;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mendes.Trucks.Tests.Application
{
	public class TruckApplicationTests
	{
		[Fact]
		public void TruckApplication_CreateViewModel()
		{
			var truckService = new Mock<ITruckAppService>();
			truckService
				.Setup(r => r.CreateViewModel())
				.Returns(new TruckViewModel { ManufactureYear = DateTime.Now.Year, ModelYear = DateTime.Now.Year, TruckModel = TruckModel.Fh });

			var result = truckService.Object.CreateViewModel();
			Assert.Equal(result.ManufactureYear, DateTime.Now.Year);
			Assert.Equal(result.ModelYear, DateTime.Now.Year);
			Assert.Equal(TruckModel.Fh, result.TruckModel);
		}

		[Fact]
		public void TruckApplication_Find()
		{
			const int id = 1;

			var truckService = new Mock<ITruckAppService>();
			truckService
				.Setup(r => r.Find(id))
				.Returns(Task.FromResult(new TruckViewModel { Id = 1 }));

			var result = truckService.Object.Find(id).Result;
			Assert.NotNull(result);
			Assert.Equal(result.Id, id);
		}

		[Fact]
		public void TruckApplication_List()
		{
			var listViewModel = new List<TruckListViewModel> { new TruckListViewModel() };
			const int countList = 1;

			var truckService = new Mock<ITruckAppService>();
			truckService
				.Setup(r => r.List())
				.Returns(Task.FromResult((IEnumerable<TruckListViewModel>)listViewModel));

			var result = truckService.Object.List().Result;
			Assert.Equal(result.Count(), countList);
		}

		[Theory]
		[InlineData(0, 2021, false)]
		[InlineData(2021, 0, false)]
		[InlineData(2021, 2020, false)]
		[InlineData(2019, 2021, false)]
		public void TruckApplication_SetPropertiesObject_IsInvalid(int manufactureYear, int modelYear, bool expectedResult)
		{
			var truckModel = new TruckViewModel
			{
				ManufactureYear = manufactureYear,
				ModelYear = modelYear
			};

			var truckService = new Mock<ITruckAppService>();
			truckService
				.Setup(r => r.Add(truckModel))
				.Returns(Task.FromResult(Result<TruckViewModel>.Create(false, "")));

			var result = truckService.Object.Add(truckModel).Result;
			Assert.Equal(result.Success, expectedResult);
		}

		[Theory]
		[InlineData(2019, 2020, true)]
		[InlineData(2020, 2020, true)]
		[InlineData(2020, 2021, true)]
		public void TruckApplication_SetPropertiesObject_IsValid(int manufactureYear, int modelYear, bool expectedResult)
		{
			var truckModel = new TruckViewModel
			{
				ManufactureYear = manufactureYear,
				ModelYear = modelYear
			};

			var truckService = new Mock<ITruckAppService>();
			truckService
				.Setup(r => r.Add(truckModel))
				.Returns(Task.FromResult(Result<TruckViewModel>.Create(true, "")));

			var result = truckService.Object.Add(truckModel).Result;
			Assert.Equal(result.Success, expectedResult);
		}
	}
}
