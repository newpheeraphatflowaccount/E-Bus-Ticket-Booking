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

		public IActionResult Index()
		{
			var subjects = _subjectRepo.GetAll();
			return View(subjects);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Subject subject)
		{
			_subjectRepo.Insert(subject);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var subject = _subjectRepo.GetById(id);
			return View(subject);
		}

		[HttpPost]
		public IActionResult Edit(Subject subject)
		{
			_subjectRepo.Update(subject);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			_subjectRepo.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
