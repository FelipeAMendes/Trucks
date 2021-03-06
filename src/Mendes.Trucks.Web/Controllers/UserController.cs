using Mendes.Trucks.Application.Interfaces;
using Mendes.Trucks.Application.ViewModels.Users;
using Mendes.Trucks.Domain;
using Mendes.Trucks.Domain.Enums;
using Mendes.Trucks.Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mendes.Trucks.Web.Controllers
{
	[AllowAnonymous]
	public class UserController : BaseController
	{
		private readonly IUserAppService _resellerAppService;

		public UserController(IUserAppService resellerAppService)
		{
			_resellerAppService = resellerAppService;
		}

		[Route("/")]
		[Route("/users")]
		[Route("/users/list")]
		public async Task<IActionResult> Index()
		{
			return View(await _resellerAppService.List());
		}

		[HttpGet]
		[Route("users/login")]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[Route("users/login")]
		public async Task<IActionResult> Login(UserLoginViewModel userViewModel)
		{
			var result = await _resellerAppService.Find(userViewModel.Cpf, userViewModel.Password);
			if (!result.Success)
			{
				ShowMessage(MessageType.Error, result.Message.ToListString());
				return View();
			}

			_resellerAppService.SetToken(result.Object);
			return RedirectToAction("Index", "Truck");
		}

		[Route("users/logout")]
		public IActionResult Logout()
		{
			_resellerAppService.RemoveToken();
			return RedirectToAction(MendesTrucksConfiguration.UseAuth ? "Login" : "Index", "User");
		}

		[Route("/users/create")]
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[Route("/users/create")]
		[HttpPost]
		public async Task<IActionResult> Create(UserViewModel userViewModel)
		{
			if (!ModelState.IsValid)
				return View(userViewModel);

			var result = await _resellerAppService.Add(userViewModel);
			if (result.Success)
			{
				ShowMessage(MessageType.Success, result.Message);
				return RedirectToAction(nameof(Index));
			}

			ShowMessage(MessageType.Error, result.Object.Errors);
			return View(userViewModel);
		}

		[Route("/users/edit/{id?}")]
		[HttpGet]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id is null || id == 0)
				return RedirectToAction(nameof(Index));

			var resellerViewModel = await _resellerAppService.Find(id.Value);
			if (resellerViewModel is null)
				return RedirectToAction(nameof(Index));

			return View(resellerViewModel);
		}

		[Route("/users/edit/{id?}")]
		[HttpPost]
		public async Task<IActionResult> Edit(UserViewModel userViewModel)
		{
			if (!ModelState.IsValid)
				return View(userViewModel);

			var result = await _resellerAppService.Edit(userViewModel);
			if (result.Success)
				return RedirectToAction(nameof(Index));

			ShowMessage(MessageType.Error, result.Object.Errors);
			return View(userViewModel);
		}

		[Route("/users/delete/{id?}")]
		[HttpGet]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id is null || id == 0)
				return RedirectToAction(nameof(Index));

			var result = await _resellerAppService.Delete(id.Value);
			if (result.Success)
			{
				ShowMessage(MessageType.Success, result.Message);
				return RedirectToAction(nameof(Index));
			}

			ShowMessage(MessageType.Error, result.Object.Errors);
			return RedirectToAction(nameof(Index));
		}
	}
}
