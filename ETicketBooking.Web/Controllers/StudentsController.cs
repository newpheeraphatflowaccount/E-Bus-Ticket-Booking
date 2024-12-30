using ETicketBooking.Web.Data;
using ETicketBooking.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETicketBooking.Web.Controllers
{
	public class StudentsController : Controller
	{
		// {base_url}/Students/Index - End, HttpRequest

		private ApplicationDbContext _context;

		public StudentsController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var student = _context.Students.ToList();

			//List<Student> student = new List<Student>();
			//student.Add(new Student { Id = 1, Name = "John" });
			//student.Add(new Student { Id = 2, Name = "Smith" });
			return View(student);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Student student)
		{
			_context.Students.Add(student);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var student = _context.Students.Find(id);
			return View(student);
		}

		[HttpPost]
		public IActionResult Edit(Student student)
		{
			_context.Students.Update(student);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var student = _context.Students.Find(id);
			_context.Students.Remove(student);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
