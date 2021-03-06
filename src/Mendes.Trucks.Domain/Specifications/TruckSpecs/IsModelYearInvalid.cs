using Mendes.Trucks.Domain.Catalog.Messages;
using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Notifications;
using System;

namespace Mendes.Trucks.Domain.Specifications.TruckSpecs
{
	public class IsModelYearInvalid : ISpecification<Truck>
	{
		public bool IsSatisfiedBy(Truck truck)
		{
			var result = truck.ManufactureYear == DateTime.Now.Year || truck.ManufactureYear == DateTime.Now.AddYears(+1).Year;
			if (!result)
				EventPublisher.OnRaiseNotificationEvent(new NotificationEventArgs(TruckMessages.ErrorModelYearInvalid));
			return result;
		}
	}
}
