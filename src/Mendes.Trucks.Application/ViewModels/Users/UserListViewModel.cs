using System.ComponentModel.DataAnnotations;

namespace Mendes.Trucks.Application.ViewModels.Users
{
	public class UserListViewModel
	{
		public int Id { get; set; }

		[Display(Name = "Nome Completo")] public string Name { get; set; }

		[Display(Name = "CPF")] public string Cpf { get; set; }

		[Display(Name = "E-mail")] public string Email { get; set; }
	}
}
