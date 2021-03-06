using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Extensions;
using Mendes.Trucks.Domain.Specifications.TruckSpecs;

namespace Mendes.Trucks.Domain.Validators.TruckValidators
{
	public class TruckValidator : IValidator
	{
		private readonly Truck _truck;

		public TruckValidator(Truck truck)
		{
			_truck = truck;
		}

		public bool Validate()
		{
			var rule =
				new IsModelYearInvalid()
					.And(new IsManufactureYearInvalid());

			return rule.IsSatisfiedBy(_truck);
		}
	}
}
