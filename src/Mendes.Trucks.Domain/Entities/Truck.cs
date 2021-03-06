using Mendes.Trucks.Domain.Enums;
using System;

namespace Mendes.Trucks.Domain.Entities
{
	public class Truck : Entity
	{
		public TruckModel TruckModel { get; set; }
		public int ManufactureYear { get; set; } = DateTime.Now.Year;
		public int ModelYear { get; set; }
		public DateTime RegisterDate { get; set; } = DateTime.Now;
	}
}
