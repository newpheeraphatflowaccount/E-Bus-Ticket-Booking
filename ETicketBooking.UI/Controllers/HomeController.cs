using System.Diagnostics;
using ETicketBooking.Entities;
using ETicketBooking.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETicketBooking.UI.Controllers
{
	// ViewBag.DynamicVariable = "Built in Types, Complex Type"
	// ViewData["Key"] = value
	// TempData["Key"] = value, Keep, Peek

	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			ViewBag.t1 = "Index Action Method";
			ViewBag.departments = new Department
			{
				Id = 1,
				Name = "IT"
			};
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
