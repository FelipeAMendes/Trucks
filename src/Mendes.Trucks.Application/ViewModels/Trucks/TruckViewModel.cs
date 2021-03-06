using Mendes.Trucks.Application.Attributes;
using Mendes.Trucks.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mendes.Trucks.Application.ViewModels.Trucks
{
	public class TruckViewModel
	{
		[Key] public int Id { get; set; }

		[Display(Name = "Modelo")]
		[Required(ErrorMessage = "Modelo do caminhão é obrigatório")]
		[Range(1, 2, ErrorMessage = "Modelo do caminhão é obrigatório")]
		public TruckModel TruckModel { get; set; }

		[Display(Name = "Ano de Fabricação")]
		[Required(ErrorMessage = "Ano de Fabricação é obrigatório")]
		public int ManufactureYear { get; set; }

		[Display(Name = "Ano Modelo")]
		[Required(ErrorMessage = "Ano Modelo é obrigatório")]
		[ModelYearValidate(nameof(ManufactureYear), ErrorMessage = "Ano Modelo é inválido")]
		public int ModelYear { get; set; }

		public IEnumerable<string> Errors { get; set; }
	}
}