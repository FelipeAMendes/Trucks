using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mendes.Trucks.Infra.Data.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(DbContext context)
			: base(context)
		{
		}

		public User Find(Expression<Func<User, bool>> predicate)
		{
			return Context
				.Set<User>()
				.FirstOrDefault(predicate);
		}

		public async Task<User> FindAsync(Expression<Func<User, bool>> predicate)
		{
			return await Context
				.Set<User>()
				.FirstOrDefaultAsync(predicate);
		}
	}
}
