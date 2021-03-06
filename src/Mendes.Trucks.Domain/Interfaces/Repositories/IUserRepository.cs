using Mendes.Trucks.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mendes.Trucks.Domain.Interfaces.Repositories
{
	public interface IUserRepository : IRepository<User>
	{
		User Find(Expression<Func<User, bool>> predicate);
		Task<User> FindAsync(Expression<Func<User, bool>> predicate);
	}
}
