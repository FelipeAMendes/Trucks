using Mendes.Trucks.Domain.Enums;

namespace Mendes.Trucks.Domain.Interfaces.Services
{
	public interface ILogService
	{
		void Add<T>(OperationLog operationLog, T @object, Platform platform);
	}
}
