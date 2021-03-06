using System.ComponentModel.DataAnnotations;

namespace Mendes.Trucks.Application.ViewModels.Trucks
{
	public class TruckListViewModel
	{
		public int Id { get; set; }

		[Display(Name = "Modelo")] public string TruckModel { get; set; }

		[Display(Name = "Ano de Fabricação")] public string ManufactureYear { get; set; }

		[Display(Name = "Ano Modelo")] public string ModelYear { get; set; }
	}
}
