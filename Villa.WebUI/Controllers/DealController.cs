using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.BusinessLayer.Abstract;
using Villa.DtoLayer.Dtos.DealDtos;
using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Controllers
{
	public class DealController : Controller
	{
		private readonly IDealService _dealService;
		private readonly IMapper _mapper;

		public DealController(IDealService dealService, IMapper mapper)
		{
			_dealService = dealService;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _dealService.TGetListAsync();
			var dealList = _mapper.Map<List<ResultDealDto>>(values);
			return View(dealList);
		}

		public async Task<IActionResult> DeleteDeal(ObjectId id)
		{
			await _dealService.TDeleteAsync(id);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> CreateDeal()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateDeal(CreateDealDto createDealDto)
		{
			var newDeal = _mapper.Map<Deal>(createDealDto);
			await _dealService.TCreateAsync(newDeal);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> UpdateDeal(ObjectId id)
		{
			var value = await _dealService.TGetByIdAsync(id);
			var updateValue = _mapper.Map<UpdateDealDto>(value);
			return View(updateValue);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateDeal(UpdateDealDto updateDealDto)
		{
			var updateValue = _mapper.Map<Deal>(updateDealDto);
			await _dealService.TUpdateAsync(updateValue);
			return RedirectToAction("Index");
		}
	}
}
