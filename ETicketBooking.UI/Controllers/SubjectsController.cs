using ETicketBooking.Entities;
using ETicketBooking.Repositories.Implementations;
using ETicketBooking.Repositories.Interfaces;
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
			var subjects = await _subjectRepo.GetAll();
			return View(subjects);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Subject subject)
		{
			await _subjectRepo.Insert(subject);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var subject = await _subjectRepo.GetById(id);
			return View(subject);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Subject subject)
		{
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
