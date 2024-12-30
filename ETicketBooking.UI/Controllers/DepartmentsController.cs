using ETicketBooking.Entities;
using ETicketBooking.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETicketBooking.UI.Controllers
{
	public class DepartmentsController : Controller
	{
		private readonly IDepartmentRepo _departmentRepo;

		public DepartmentsController(IDepartmentRepo departmentRepo)
		{
			_departmentRepo = departmentRepo;
		}

		public IActionResult Index()
		{
			var departments = _departmentRepo.GetAll();
			return View(departments);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Department department)
		{
			_departmentRepo.Insert(department);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var department = _departmentRepo.GetById(id);
			return View(department);
		}

		[HttpPost]
		public IActionResult Edit(Department department)
		{
			_departmentRepo.Update(department);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			_departmentRepo.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
