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

		public async Task<IActionResult> Index()
		{
			var departments = await _departmentRepo.GetAll();
			return View(departments);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Department department)
		{
			await _departmentRepo.Insert(department);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var department = await _departmentRepo.GetById(id);
			return View(department);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Department department)
		{
			await _departmentRepo.Update(department);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			await _departmentRepo.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
