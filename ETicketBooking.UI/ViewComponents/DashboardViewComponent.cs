using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.Repositories.Interfaces;
using ETicketBooking.UI.ViewModels.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace ETicketBooking.UI.ViewComponents
{
	public class DashboardViewComponent : ViewComponent
	{
		private readonly IDepartmentRepo _departmentRepo;
		private readonly IStudentRepo _studentRepo;
		private readonly IEmployeeRepo _employeeRepo;

		public DashboardViewComponent(IDepartmentRepo departmentRepo,
			IStudentRepo studentRepo,
			IEmployeeRepo employeeRepo)
		{
			_departmentRepo = departmentRepo;
			_studentRepo = studentRepo;
			_employeeRepo = employeeRepo;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var vm = new Dashboard
			{
				TotalDepartment = _departmentRepo.GetAll().GetAwaiter().GetResult().Count(),
				TotalStudent = _studentRepo.GetAll().GetAwaiter().GetResult().Count(),
				TotalEmployee = _employeeRepo.GetAll().GetAwaiter().GetResult().Count()
			};
			return View(vm);
		}
	}
}
