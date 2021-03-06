using Mendes.Trucks.Domain.Extensions;

namespace Mendes.Trucks.Domain.Entities
{
	public class User : Entity
	{
		public string Name { get; set; }
		public string Cpf { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
		public bool? Enabled { get; set; }

		public User SetRole()
		{
			Role = nameof(User);
			return this;
		}

		public User SetPassword()
		{
			Password = CryptographyExtensions.Sha256Hash(Password);
			return this;
		}

		public User Clear()
		{
			if (!Cpf.IsNullOrWhiteSpace())
				Cpf = Cpf.Replace(".", "").Replace(",", "").Replace("-", "");

			return this;
		}
	}
}
