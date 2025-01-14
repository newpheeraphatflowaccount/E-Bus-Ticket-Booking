using AutoMapper;
using ETicketBooking.Entities;
using ETicketBooking.Repositories.Implementations;
using ETicketBooking.Repositories.Interfaces;
using ETicketBooking.UI.ViewModels.SubjectViewModels;
using ETicketBooking.UI.ViewModels.Utility;
using Microsoft.AspNetCore.Mvc;

namespace ETicketBooking.UI.Controllers
{
	public class SubjectsController : Controller
	{
		private readonly IMapper _mapper;
		private readonly ISubjectRepo _subjectRepo;

		public SubjectsController(ISubjectRepo subjectRepo, IMapper mapper)
		{
			_subjectRepo = subjectRepo;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index(string sortOrder,
			string currentFilter,
			int pageNumber = 1,
			int pageSize = 3,
			string searchText = null)
		{
			ViewData["CurrentSort"] = sortOrder;
			ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) || sortOrder == "name_asc" ? "name_desc" : "name_asc";
			ViewData["IdSortParam"] = sortOrder == "id_desc" ? "" : "id_desc";
			var subjects = await _subjectRepo.GetAll();
			var totalItems = 0;
			if (searchText != null)
			{
				pageNumber = 1;

			} 
			else
			{
				searchText = currentFilter;
			}
			ViewData["CurrentFilterData"] = searchText;


			if (!string.IsNullOrEmpty(searchText))
			{
				subjects = subjects.Where(x => x.Name.Contains(searchText));
			}

			totalItems = subjects.ToList().Count();

			switch (sortOrder)
			{
				case "name_desc": subjects = subjects.OrderByDescending(x => x.Name); 
					break;
				case "name_asc": subjects = subjects.OrderBy(x => x.Name);
					break;
				case "id_desc": subjects = subjects.OrderByDescending(x => x.Id);
					break;
				default: subjects = subjects.OrderBy(x => x.Id);
					break;
			}


			subjects = subjects.Skip((pageNumber - 1) * pageSize).Take(pageSize);

			var subjectViewModels = _mapper.Map<List<SubjectViewModel>>(subjects);

			var pagedSubjectViewModel = new PagedSubjectViewModel
			{
				SubjectViewModelList = subjectViewModels,
				PageInfo = new PageInfo
				{
					TotalItems = totalItems,
					PageNumber = pageNumber,
					PageSize = pageSize,
				}
			};

			return View(pagedSubjectViewModel);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateSubjectViewModel vm)
		{
			var subject = new Subject
			{
				Name = vm.Name
			};
			await _subjectRepo.Insert(subject);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var subject = await _subjectRepo.GetById(id);
			var vm = new SubjectViewModel
			{
				Id = subject.Id,
				Name = subject.Name
			};
			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(SubjectViewModel vm)
		{
			var subject = new Subject
			{
				Id = vm.Id,
				Name = vm.Name
			};
			await _subjectRepo.Update(subject);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			await _subjectRepo.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
