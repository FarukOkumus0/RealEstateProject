using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.BusinessLayer.Abstract;
using Villa.DtoLayer.Dtos.CounterDtos;
using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Controllers
{
	public class CounterController : Controller
	{
		private readonly ICounterService _counterService;
		private readonly IMapper _mapper;

		public CounterController(ICounterService counterService, IMapper mapper)
		{
			_counterService = counterService;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _counterService.TGetListAsync();
			var counterList = _mapper.Map<List<ResultCounterDto>>(values);
			return View(counterList);
		}

		public async Task<IActionResult> DeleteCounter(ObjectId id)
		{
			await _counterService.TDeleteAsync(id);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> CreateCounter()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateCounter(CreateCounterDto createCounterDto)
		{
			var newCounter = _mapper.Map<Counter>(createCounterDto);
			await _counterService.TCreateAsync(newCounter);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> UpdateCounter(ObjectId id)
		{
			var value = await _counterService.TGetByIdAsync(id);
			var Counter = _mapper.Map<UpdateCounterDto>(value);
			return View(Counter);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateCounter(UpdateCounterDto updateCounterDto)
		{
			var Counter = _mapper.Map<Counter>(updateCounterDto);
			await _counterService.TUpdateAsync(Counter);
			return RedirectToAction("Index");
		}
	}
}
