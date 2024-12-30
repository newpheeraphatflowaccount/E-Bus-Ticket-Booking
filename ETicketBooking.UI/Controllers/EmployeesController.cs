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

		public IActionResult Index()
		{
			var employees = _employeeRepo.GetAll();
			return View(employees);
		}

		[HttpGet]
		public IActionResult Create()
		{
			var department = _departmentRepo.GetAll();
			ViewBag.departmentsList = new SelectList(department, "Id", "Name");
			return View();
		}

		[HttpPost]
		public IActionResult Create(Employee employee)
		{
			_employeeRepo.Insert(employee);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var employee = _employeeRepo.GetById(id);
			var department = _departmentRepo.GetAll();
			ViewBag.departmentsList = new SelectList(department, "Id", "Name");
			return View(employee);
		}

		[HttpPost]
		public IActionResult Edit(Employee employee)
		{
			_employeeRepo.Update(employee);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			_employeeRepo.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
