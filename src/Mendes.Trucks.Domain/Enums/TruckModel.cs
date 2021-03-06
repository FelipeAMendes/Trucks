using System.ComponentModel.DataAnnotations;

namespace Mendes.Trucks.Domain.Enums
{
	public enum TruckModel
	{
		[Display(Name = "FH")] Fh = 1,
		[Display(Name = "FM")] Fm
	}
}
