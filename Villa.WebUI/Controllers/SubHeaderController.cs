using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.BusinessLayer.Abstract;
using Villa.DtoLayer.Dtos.SubHeaderDtos;
using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Controllers
{
	public class SubHeaderController : Controller
	{
		private readonly ISubHeaderService _subHeaderService;
		private readonly IMapper _mapper;

		public SubHeaderController(ISubHeaderService subHeaderService, IMapper mapper)
		{
			_subHeaderService = subHeaderService;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _subHeaderService.TGetListAsync();
			var SubHeaderList = _mapper.Map<List<ResultSubHeaderDto>>(values);
			return View(SubHeaderList);
		}

		public async Task<IActionResult> DeleteSubHeader(ObjectId id)
		{
			await _subHeaderService.TDeleteAsync(id);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> CreateSubHeader()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateSubHeader(CreateSubHeaderDto createSubHeaderDto)
		{
			var newSubHeader = _mapper.Map<SubHeader>(createSubHeaderDto);
			await _subHeaderService.TCreateAsync(newSubHeader);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> UpdateSubHeader(ObjectId id)
		{
			var value = await _subHeaderService.TGetByIdAsync(id);
			var updateValue = _mapper.Map<UpdateSubHeaderDto>(value);
			return View(updateValue);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateSubHeader(UpdateSubHeaderDto updateSubHeaderDto)
		{
			var updateValue = _mapper.Map<SubHeader>(updateSubHeaderDto);
			await _subHeaderService.TUpdateAsync(updateValue);
			return RedirectToAction("Index");
		}
	}
}
