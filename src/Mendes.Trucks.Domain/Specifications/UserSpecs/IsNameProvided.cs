using Mendes.Trucks.Domain.Catalog.Messages;
using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Extensions;
using Mendes.Trucks.Domain.Notifications;

namespace Mendes.Trucks.Domain.Specifications.UserSpecs
{
	public class IsNameProvided : ISpecification<User>
	{
		public bool IsSatisfiedBy(User user)
		{
			var result = !user.Name.IsNullOrWhiteSpace();
			if (!result)
				EventPublisher.OnRaiseNotificationEvent(new NotificationEventArgs(UserMessages.ErrorNameNotProvided));
			return result;
		}
	}
}
