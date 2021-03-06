using Mendes.Trucks.Domain.Catalog.Messages;
using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Interfaces.Repositories;
using Mendes.Trucks.Domain.Notifications;

namespace Mendes.Trucks.Domain.Specifications.UserSpecs
{
	public class ExistingEmail : ISpecification<User>
	{
		private readonly IUserRepository _userRepository;

		public ExistingEmail(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public bool IsSatisfiedBy(User user)
		{
			var result = user.Id > 0
				? _userRepository.Find(u => u.Id != user.Id && u.Email == user.Email)
				: _userRepository.Find(u => u.Email == user.Email);

			if (result?.Id > 0)
				EventPublisher.OnRaiseNotificationEvent(new NotificationEventArgs(UserMessages.ErrorExistingEmail));

			return !(result?.Id > 0);
		}
	}
}
