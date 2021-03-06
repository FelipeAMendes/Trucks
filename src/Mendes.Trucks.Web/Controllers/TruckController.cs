using Mendes.Trucks.Application.Interfaces;
using Mendes.Trucks.Application.ViewModels.Trucks;
using Mendes.Trucks.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mendes.Trucks.Web.Controllers
{
	[AllowAnonymous]
	public class TruckController : BaseController
	{
		private readonly ITruckAppService _truckAppService;

		public TruckController(ITruckAppService truckAppService)
		{
			_truckAppService = truckAppService;
		}

		[Route("/trucks/")]
		[Route("/trucks/index")]
		[Route("/trucks/list")]
		public async Task<IActionResult> Index()
		{
			var trucks = await _truckAppService.List();
			return View(trucks);
		}

		[Route("/trucks/create")]
		[HttpGet]
		public IActionResult Create()
		{
			var viewModel = _truckAppService.CreateViewModel();
			return View(viewModel);
		}

		[Route("/trucks/create")]
		[HttpPost]
		public async Task<IActionResult> Create(TruckViewModel truckViewModel)
		{
			if (!ModelState.IsValid)
				return View(truckViewModel);

			var result = await _truckAppService.Add(truckViewModel);
			if (result.Success)
			{
				ShowMessage(MessageType.Success, result.Message);
				return RedirectToAction(nameof(Index));
			}

			ShowMessage(MessageType.Error, result.Object.Errors);
			return View(truckViewModel);
		}

		[Route("/trucks/edit/{id?}")]
		[HttpGet]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id is null || id == 0)
				return RedirectToAction(nameof(Index));

			var truckViewModel = await _truckAppService.Find(id.Value);
			if (truckViewModel is null)
				return RedirectToAction(nameof(Index));

			return View(truckViewModel);
		}

		[Route("/trucks/edit/{id?}")]
		[HttpPost]
		public async Task<IActionResult> Edit(TruckViewModel truckViewModel)
		{
			if (!ModelState.IsValid)
				return View(truckViewModel);

			var result = await _truckAppService.Edit(truckViewModel);
			if (result.Success)
			{
				ShowMessage(MessageType.Success, result.Message);
				return RedirectToAction(nameof(Index));
			}

			ShowMessage(MessageType.Error, result.Object.Errors);
			return View(truckViewModel);
		}

		[Route("/trucks/delete/{id?}")]
		[HttpGet]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id is null || id == 0)
				return RedirectToAction(nameof(Index));

			var result = await _truckAppService.Delete(id.Value);
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
