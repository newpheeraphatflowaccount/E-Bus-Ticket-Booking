using AutoMapper;
using ETicketBooking.Entities;
using ETicketBooking.Repositories.Interfaces;
using ETicketBooking.UI.ViewModels.DepartmentViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ETicketBooking.UI.Controllers
{
	public class DepartmentsController : Controller
	{
		private readonly IDepartmentRepo _departmentRepo;
		private readonly IMapper _mapper;

		public DepartmentsController(IDepartmentRepo departmentRepo, IMapper mapper)
		{
			_departmentRepo = departmentRepo;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			if (HttpContext.Session.GetInt32("userId") != null)
			{
				//List<DepartmentViewModel> departmentViewModels = new List<DepartmentViewModel>();
				var departments = await _departmentRepo.GetAll();

				var departmentViewModels = _mapper.Map<List<DepartmentViewModel>>(departments);

				//foreach (var department in departments)
				//{
				//	departmentViewModels.Add(new DepartmentViewModel
				//	{
				//		Id = department.Id,
				//		Name = department.Name
				//	});
				//}f
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
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateDepartmentViewModel vm)
		{
			if (ModelState.IsValid)
			{
				var department = _mapper.Map<Department>(vm);
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
			var vm = _mapper.Map<DepartmentViewModel>(department);
			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(DepartmentViewModel vm)
		{
			var department = _mapper.Map<Department>(vm);
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
