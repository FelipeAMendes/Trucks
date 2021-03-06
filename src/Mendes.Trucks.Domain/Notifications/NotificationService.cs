namespace Mendes.Trucks.Domain.Notifications
{
	public abstract class NotificationService
	{
		protected readonly Notification Notifier;

		protected NotificationService()
		{
			Notifier = new Notification();
		}
	}
}
