using System.Collections.Generic;

namespace Mendes.Trucks.Domain.Notifications
{
	public class Notification
	{
		public IList<string> Errors { get; }

		public Notification()
		{
			Errors = new List<string>();
		}
	}
}
