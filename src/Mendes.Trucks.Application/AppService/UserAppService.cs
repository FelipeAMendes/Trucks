using AutoMapper;
using Mendes.Trucks.Application.Interfaces;
using Mendes.Trucks.Application.ViewModels.Users;
using Mendes.Trucks.Domain;
using Mendes.Trucks.Domain.Catalog.Messages;
using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Interfaces.Repositories;
using Mendes.Trucks.Domain.Interfaces.Services;
using Mendes.Trucks.Domain.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mendes.Trucks.Application.AppService
{
	public class UserAppService : IUserAppService
	{
		private readonly IMapper _mapper;
		private readonly IUserService _userService;
		private readonly ITokenService _tokenService;
		private readonly IUserRepository _userRepository;

		private readonly IResponseCookies _responseCookies;
		private readonly IRequestCookieCollection _requestCookies;

		public UserAppService(
			IMapper mapper,
			IUserService userService,
			ITokenService tokenService,
			IUserRepository userRepository,
			IHttpContextAccessor httpContextAccessor)
		{
			_mapper = mapper;
			_userService = userService;
			_tokenService = tokenService;
			_userRepository = userRepository;

			_responseCookies = httpContextAccessor.HttpContext.Response.Cookies;
			_requestCookies = httpContextAccessor.HttpContext.Request.Cookies;
		}

		public async Task<UserViewModel> Find(int id)
		{
			var reseller = await _userRepository.Find(id);
			return _mapper.Map<UserViewModel>(reseller);
		}

		public async Task<Result<User>> Find(string cpf, string password)
		{
			return await _userService.Find(cpf, password);
		}

		public async Task<IEnumerable<UserListViewModel>> List()
		{
			IEnumerable<User> usersList = await _userRepository
				.List(r => r.Enabled == true)
				.ToListAsync();

			return _mapper.Map<IEnumerable<UserListViewModel>>(usersList);
		}

		public async Task<Result<UserViewModel>> Add(UserViewModel viewModel)
		{
			var entity = _mapper.Map<User>(viewModel);
			var result = await _userService.Add(entity);

			if (!result.Success)
				viewModel.Errors = result.Object;

			return Result<UserViewModel>.Create(result.Success, result.Message, viewModel);
		}

		public async Task<Result<UserViewModel>> Edit(UserViewModel viewModel)
		{
			var entity = await _userRepository.Find(viewModel.Id);
			entity.Name = viewModel.Name;
			entity.Email = viewModel.Email;
			var result = await _userService.Edit(entity);

			if (!result.Success)
				viewModel.Errors = result.Object;

			return Result<UserViewModel>.Create(result.Success, result.Message, viewModel);
		}

		public async Task<Result<UserViewModel>> Delete(int id)
		{
			var entity = await _userRepository.Find(id);
			_userRepository.Delete(entity);
			await _userRepository.Save();
			return Result<UserViewModel>.Create(true, UserMessages.DeleteSuccess);
		}

		public void SetToken(User user)
		{
			var token = _tokenService.Generate(user);
			var option = new CookieOptions { Expires = DateTime.Now.AddHours(2) };
			_responseCookies.Append(MendesTrucksConfiguration.Jwt.CookieName, token, option);
		}

		public void RemoveToken()
		{
			var hasCookie = _requestCookies.ContainsKey(MendesTrucksConfiguration.Jwt.CookieName);
			if (hasCookie)
				_responseCookies.Delete(MendesTrucksConfiguration.Jwt.CookieName);
		}
	}
}
