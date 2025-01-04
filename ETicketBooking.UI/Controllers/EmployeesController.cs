using ETicketBooking.Entities;
using ETicketBooking.Repositories.Interfaces;
using ETicketBooking.UI.ViewModels.EmployeeViewModels;
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
			List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
			var employees = await _employeeRepo.GetAll();
			foreach (var item in employees)
			{
				employeeViewModels.Add(new EmployeeViewModel
				{
					Id=item.Id,
					Name=item.Name,
					DepartmentName=item.Department.Name
				});
			}
			return View(employeeViewModels);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var department = await _departmentRepo.GetAll();
			ViewBag.departmentsList = new SelectList(department, "Id", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateEmployeeViewModel vm)
		{
			var employee = new Employee
			{
				Name = vm.Name,
				DepartmentId = vm.DepartmentId
			};
			await _employeeRepo.Insert(employee);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var employee = await _employeeRepo.GetById(id);
			var vm = new EditEmployeeViewModel
			{
				Id = employee.Id,
				Name = employee.Name,
				DepartmentId = employee.DepartmentId
			};

			var department = await _departmentRepo.GetAll();
			ViewBag.departmentsList = new SelectList(department, "Id", "Name");
			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(EditEmployeeViewModel vm)
		{
			var employee = new Employee
			{
				Id = vm.Id,
				Name = vm.Name,
				DepartmentId = vm.DepartmentId
			};
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
