namespace Mendes.Trucks.Domain.Results
{
	public class Result<T> where T : class
	{
		private Result(bool success, string message, T @object)
		{
			Success = success;
			Message = message;
			Object = @object;
		}

		public bool Success { get; }
		public string Message { get; }
		public T Object { get; }

		public static Result<T> Create(bool success, string message)
			=> new Result<T>(success, message, null);

		public static Result<T> Create(bool success, T @object)
			=> new Result<T>(success, null, @object);

		public static Result<T> Create(bool success, string mensagem, T @object)
			=> new Result<T>(success, mensagem, @object);
	}
}
