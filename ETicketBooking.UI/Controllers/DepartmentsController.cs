using ETicketBooking.Entities;
using ETicketBooking.Repositories.Interfaces;
using ETicketBooking.UI.ViewModels.DepartmentViewModels;
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
			if (HttpContext.Session.GetInt32("userId") != null)
			{
				List<DepartmentViewModel> departmentViewModels = new List<DepartmentViewModel>();
				var departments = await _departmentRepo.GetAll();
				foreach (var department in departments)
				{
					departmentViewModels.Add(new DepartmentViewModel
					{
						Id = department.Id,
						Name = department.Name
					});
				}
				return View(departmentViewModels);
			}
			return RedirectToAction("Login", "Auth");
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateDepartmentViewModel vm)
		{
			if (ModelState.IsValid)
			{
				var department = new Department
				{
					Name = vm.Name
				};
				var record = await _departmentRepo.Insert(department);

				if (record > 0)
				{
					TempData["success"] = "Record Inserted";
					return RedirectToAction("Index");
				}
				else
				{
					TempData["error"] = "Record not Inserted";
					return View();
				}
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var department = await _departmentRepo.GetById(id);
			var vm = new DepartmentViewModel
			{
				Id = department.Id,
				Name = department.Name
			};
			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(DepartmentViewModel vm)
		{
			var department = new Department
			{
				Id = vm.Id,
				Name = vm.Name
			};
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
