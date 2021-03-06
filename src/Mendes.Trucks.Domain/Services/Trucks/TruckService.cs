using Mendes.Trucks.Domain.Catalog.Messages;
using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Enums;
using Mendes.Trucks.Domain.Interfaces.Repositories;
using Mendes.Trucks.Domain.Interfaces.Services;
using Mendes.Trucks.Domain.Notifications;
using Mendes.Trucks.Domain.Results;
using Mendes.Trucks.Domain.Validators.TruckValidators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mendes.Trucks.Domain.Services.Trucks
{
	public class TruckService : Service<Truck>, ITruckService
	{
		private readonly ITruckRepository _truckRepository;
		private readonly ILogService _logService;

		public TruckService(ITruckRepository truckRepository, ILogService logService)
		{
			_truckRepository = truckRepository;
			_logService = logService;
		}

		public async Task<Result<IEnumerable<string>>> Add(Truck truck)
		{
			var resultValidation = Validate(truck);
			if (resultValidation.Errors.Count > 0)
				return Result<IEnumerable<string>>.Create(false, resultValidation.Errors);

			_truckRepository.Add(truck);
			_logService.Add(OperationLog.Insert, truck, Platform.Web);
			await _truckRepository.Save();
			return Result<IEnumerable<string>>.Create(true, TruckMessages.RegisterSuccess);
		}

		public async Task<Result<IEnumerable<string>>> Edit(Truck truck)
		{
			var resultValidation = Validate(truck);
			if (resultValidation.Errors.Count > 0)
				return Result<IEnumerable<string>>.Create(false, resultValidation.Errors);

			_truckRepository.Update(truck);
			_logService.Add(OperationLog.Update, truck, Platform.Web);
			await _truckRepository.Save();
			return Result<IEnumerable<string>>.Create(true, TruckMessages.EditSuccess);
		}

		public override Notification Validate(Truck truck)
		{
			var validator = new TruckValidator(truck);
			EventPublisher.RaiseNotificationEvent += HandleNotificationEvent;
			_ = validator.Validate();
			return Notifier;
		}
	}
}
