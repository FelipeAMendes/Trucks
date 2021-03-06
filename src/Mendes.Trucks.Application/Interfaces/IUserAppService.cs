using Mendes.Trucks.Application.ViewModels.Users;
using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mendes.Trucks.Application.Interfaces
{
	public interface IUserAppService
	{
		Task<UserViewModel> Find(int id);
		Task<Result<User>> Find(string cpf, string password);
		void SetToken(User user);
		void RemoveToken();

		Task<IEnumerable<UserListViewModel>> List();

		Task<Result<UserViewModel>> Add(UserViewModel entity);
		Task<Result<UserViewModel>> Edit(UserViewModel entity);
		Task<Result<UserViewModel>> Delete(int id);
	}
}
