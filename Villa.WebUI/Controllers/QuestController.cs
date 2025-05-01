using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.BusinessLayer.Abstract;
using Villa.BusinessLayer.Validators;
using Villa.DtoLayer.Dtos.QuestDtos;
using Villa.EntityLayer.Entities;

namespace Villa.WebUI.Controllers
{
	public class QuestController : Controller
	{

		private readonly IQuestService _questService;
		private readonly IMapper _mapper;

		public QuestController(IQuestService questService, IMapper mapper)
		{
			_questService = questService;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _questService.TGetListAsync();
			var QuestList = _mapper.Map<List<ResultQuestDto>>(values);
			return View(QuestList);
		}

		public async Task<IActionResult> DeleteQuest(ObjectId id)
		{
			await _questService.TDeleteAsync(id);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> CreateQuest()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateQuest(CreateQuestDto createQuestDto)
		{
			ModelState.Clear();
			var newValue = _mapper.Map<Quest>(createQuestDto);
			var validator = new QuestValidator();
			var result = validator.Validate(newValue);
			if (!result.IsValid)
			{
				result.Errors.ForEach(x =>
				{
					ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
				});
				return View();
			}
			await _questService.TCreateAsync(newValue);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> UpdateQuest(ObjectId id)
		{
			var value = await _questService.TGetByIdAsync(id);
			var updateValue = _mapper.Map<UpdateQuestDto>(value);
			return View(updateValue);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateQuest(UpdateQuestDto updateQuestDto)
		{
			var updateValue = _mapper.Map<Quest>(updateQuestDto);
			await _questService.TUpdateAsync(updateValue);
			return RedirectToAction("Index");
		}


	}
}
