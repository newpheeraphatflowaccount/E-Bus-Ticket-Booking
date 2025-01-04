using ETicketBooking.Entities;
using ETicketBooking.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ETicketBooking.UI.Controllers
{
	public class EmployeesController : Controller
	{
		private readonly IEmployeeRepo _employeeRepo;
		private readonly IDepartmentRepo _departmentRepo;

		public EmployeesController(IEmployeeRepo employeeRepo, IDepartmentRepo departmentRepo)
		{
			_employeeRepo = employeeRepo;
			_departmentRepo = departmentRepo;
		}

		public async Task<IActionResult> Index()
		{
			var employees = await _employeeRepo.GetAll();
			return View(employees);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var department = await _departmentRepo.GetAll();
			ViewBag.departmentsList = new SelectList(department, "Id", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Employee employee)
		{
			await _employeeRepo.Insert(employee);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var employee = await _employeeRepo.GetById(id);
			var department = await _departmentRepo.GetAll();
			ViewBag.departmentsList = new SelectList(department, "Id", "Name");
			return View(employee);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Employee employee)
		{
			await _employeeRepo.Update(employee);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			await _employeeRepo.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
