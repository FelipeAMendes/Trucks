using Mendes.Trucks.Domain.Catalog.Messages;
using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Enums;
using Mendes.Trucks.Domain.Interfaces.Repositories;
using Mendes.Trucks.Domain.Interfaces.Services;
using Mendes.Trucks.Domain.Notifications;
using Mendes.Trucks.Domain.Results;
using Mendes.Trucks.Domain.Validators.UserValidators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mendes.Trucks.Domain.Services.Users
{
	public class UserService : Service<User>, IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly ILogService _logService;

		public UserService(IUserRepository userRepository, ILogService logService)
		{
			_userRepository = userRepository;
			_logService = logService;
		}

		public async Task<Result<User>> Find(string cpf, string password)
		{
			var user = new User
			{
				Cpf = cpf,
				Password = password
			};

			user.Clear().SetPassword();
			var userRepository = await _userRepository.FindAsync(u =>
				u.Cpf == user.Cpf &&
				u.Password == user.Password);

			return userRepository is null
				? Result<User>.Create(false, UserMessages.ErrorLogin)
				: Result<User>.Create(true, userRepository);
		}

		public async Task<Result<IEnumerable<string>>> Add(User user)
		{
			user.Clear().SetRole().SetPassword();
			var resultValidation = Validate(user);
			if (resultValidation.Errors.Count > 0)
				return Result<IEnumerable<string>>.Create(false, resultValidation.Errors);

			_userRepository.Add(user);
			_logService.Add(OperationLog.Insert, user, Platform.Web);
			await _userRepository.Save();
			return Result<IEnumerable<string>>.Create(true, UserMessages.RegisterSuccess);
		}

		public async Task<Result<IEnumerable<string>>> Edit(User user)
		{
			user.Clear();
			var resultValidation = Validate(user);
			if (resultValidation.Errors.Count > 0)
				return Result<IEnumerable<string>>.Create(false, resultValidation.Errors);

			_userRepository.Update(user);
			_logService.Add(OperationLog.Update, user, Platform.Web);
			await _userRepository.Save();
			return Result<IEnumerable<string>>.Create(true, UserMessages.EditSuccess);
		}

		public override Notification Validate(User user)
		{
			var validator = new UserValidator(user, _userRepository);
			EventPublisher.RaiseNotificationEvent += HandleNotificationEvent;
			_ = validator.Validate();
			return Notifier;
		}
	}
}
