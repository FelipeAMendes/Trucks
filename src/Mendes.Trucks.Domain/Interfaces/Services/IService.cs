using Mendes.Trucks.Domain.Notifications;

namespace Mendes.Trucks.Domain.Interfaces.Services
{
	public abstract class Service<TEntity> : NotificationService
	{
		public abstract Notification Validate(TEntity entity);

		protected void HandleNotificationEvent(object sender, NotificationEventArgs notificationEventArgs)
		{
			Notifier.Errors.Add(notificationEventArgs.Message);
		}
	}
}
