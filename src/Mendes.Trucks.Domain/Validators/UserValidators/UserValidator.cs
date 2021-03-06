using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Extensions;
using Mendes.Trucks.Domain.Interfaces.Repositories;
using Mendes.Trucks.Domain.Specifications.UserSpecs;

namespace Mendes.Trucks.Domain.Validators.UserValidators
{
	public class UserValidator : IValidator
	{
		private readonly User _user;
		private readonly IUserRepository _userRepository;

		public UserValidator(User user, IUserRepository userRepository)
		{
			_user = user;
			_userRepository = userRepository;
		}

		public bool Validate()
		{
			var rule =
				new IsCpfProvided()
					.And(new IsNameProvided()
						.And(new IsEmailProvided())
						.And(new IsCpfValid())
						.And(new IsEmailValid())
						.And(new ExistingCpf(_userRepository))
						.And(new ExistingEmail(_userRepository)));

			return rule.IsSatisfiedBy(_user);
		}
	}
}
