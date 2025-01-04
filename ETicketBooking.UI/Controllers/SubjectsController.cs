using ETicketBooking.Entities;
using ETicketBooking.Repositories.Implementations;
using ETicketBooking.Repositories.Interfaces;
using ETicketBooking.UI.ViewModels.SubjectViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ETicketBooking.UI.Controllers
{
	public class SubjectsController : Controller
	{
		private readonly ISubjectRepo _subjectRepo;
		
		public SubjectsController(ISubjectRepo subjectRepo)
		{
			_subjectRepo = subjectRepo;
		}

		public async Task<IActionResult> Index()
		{
			List<SubjectViewModel> subjectViewModels = new List<SubjectViewModel>();
			var subjects = await _subjectRepo.GetAll();
			foreach (var subject in subjects)
			{
				subjectViewModels.Add(new SubjectViewModel
				{
					Id = subject.Id,
					Name = subject.Name
				});
			}
			return View(subjectViewModels);
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
