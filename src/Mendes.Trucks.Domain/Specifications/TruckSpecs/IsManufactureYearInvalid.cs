using Mendes.Trucks.Domain.Catalog.Messages;
using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Notifications;
using System;

namespace Mendes.Trucks.Domain.Specifications.TruckSpecs
{
	public class IsManufactureYearInvalid : ISpecification<Truck>
	{
		public bool IsSatisfiedBy(Truck truck)
		{
			var result = truck.ManufactureYear == DateTime.Now.Year;
			if (!result)
				EventPublisher.OnRaiseNotificationEvent(new NotificationEventArgs(TruckMessages.ErrorManufactureYearInvalid));
			return result;
		}
	}
}
