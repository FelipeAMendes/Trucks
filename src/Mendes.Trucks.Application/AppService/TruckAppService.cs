using AutoMapper;
using Mendes.Trucks.Application.Interfaces;
using Mendes.Trucks.Application.ViewModels.Trucks;
using Mendes.Trucks.Domain.Catalog.Messages;
using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Interfaces.Repositories;
using Mendes.Trucks.Domain.Interfaces.Services;
using Mendes.Trucks.Domain.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mendes.Trucks.Application.AppService
{
	public class TruckAppService : ITruckAppService
	{
		private readonly IMapper _mapper;
		private readonly ITruckService _truckService;
		private readonly ITruckRepository _truckRepository;

		public TruckAppService(
			IMapper mapper,
			ITruckService truckService,
			ITruckRepository truckRepository)
		{
			_mapper = mapper;
			_truckService = truckService;
			_truckRepository = truckRepository;
		}

		public async Task<TruckViewModel> Find(int id)
		{
			var purchase = await _truckRepository.Find(id);
			return _mapper.Map<TruckViewModel>(purchase);
		}

		public async Task<IEnumerable<TruckListViewModel>> List()
		{
			IEnumerable<Truck> trucksList = await _truckRepository
				.List()
				.ToListAsync();

			var trucksViewModel = _mapper.Map<IEnumerable<TruckListViewModel>>(trucksList);
			return trucksViewModel;
		}

		public TruckViewModel CreateViewModel()
		{
			return new TruckViewModel
			{
				ManufactureYear = DateTime.Now.Year,
				ModelYear = DateTime.Now.Year
			};
		}

		public async Task<Result<TruckViewModel>> Add(TruckViewModel viewModel)
		{
			var entity = _mapper.Map<Truck>(viewModel);
			var result = await _truckService.Add(entity);

			if (!result.Success)
				viewModel.Errors = result.Object;

			return Result<TruckViewModel>.Create(result.Success, result.Message, viewModel);
		}

		public async Task<Result<TruckViewModel>> Edit(TruckViewModel viewModel)
		{
			var entity = _mapper.Map<Truck>(viewModel);
			var result = await _truckService.Edit(entity);

			if (!result.Success)
				viewModel.Errors = result.Object;

			return Result<TruckViewModel>.Create(result.Success, result.Message, viewModel);
		}

		public async Task<Result<TruckViewModel>> Delete(int id)
		{
			var entity = await _truckRepository.Find(id);
			_truckRepository.Delete(entity);
			await _truckRepository.Save();
			return Result<TruckViewModel>.Create(true, TruckMessages.DeleteSuccess);
		}
	}
}
