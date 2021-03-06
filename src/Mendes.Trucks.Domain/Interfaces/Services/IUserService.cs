using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mendes.Trucks.Domain.Interfaces.Services
{
	public interface IUserService
	{
		Task<Result<User>> Find(string cpf, string password);
		Task<Result<IEnumerable<string>>> Add(User user);
		Task<Result<IEnumerable<string>>> Edit(User user);
	}
}
