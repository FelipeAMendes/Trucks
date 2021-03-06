using System.ComponentModel.DataAnnotations;

namespace Mendes.Trucks.Application.ViewModels.Users
{
	public class UserLoginViewModel
	{
		[Display(Name = "CPF")]
		[Required(ErrorMessage = "CPF é obrigatório")]
		[StringLength(14, ErrorMessage = "CPF informado é inválido")]
		public string Cpf { get; set; }

		[Display(Name = "Senha")]
		[Required(ErrorMessage = "Senha é obrigatória")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
