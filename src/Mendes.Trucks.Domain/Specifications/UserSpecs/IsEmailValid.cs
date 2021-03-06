using Mendes.Trucks.Domain.Catalog.Messages;
using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Extensions;
using Mendes.Trucks.Domain.Notifications;

namespace Mendes.Trucks.Domain.Specifications.UserSpecs
{
	public class IsEmailValid : ISpecification<User>
	{
		public bool IsSatisfiedBy(User user)
		{
			var result = user.Email.IsValidEmail();
			if (!result)
				EventPublisher.OnRaiseNotificationEvent(new NotificationEventArgs(UserMessages.ErrorEmailInvalid));
			return result;
		}
	}
}
