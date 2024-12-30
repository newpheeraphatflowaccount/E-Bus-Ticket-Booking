using ETicketBooking.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETicketBooking.Web.Controllers
{
	public class StudentController : Controller
	{
		// {base_url}/Students/Index - End, HttpRequest
		public IActionResult Index()
		{
			List<Student> student = new List<Student>();
			student.Add(new Student { Id = 1, Name = "John" });
			student.Add(new Student { Id = 2, Name = "Smith" });
			return View();
		}
	}
}
