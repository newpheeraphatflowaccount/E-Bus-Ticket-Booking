using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.Entities;
using ETicketBooking.Repositories.Interfaces;

namespace ETicketBooking.Repositories.Implementations
{
	public class StudentRepo : IStudentRepo
	{
		private readonly ApplicationDbContext _context;

		public StudentRepo(ApplicationDbContext context)
		{
			_context = context;
		}

		public void Delete(int id)
		{
			var student = GetById(id);
			_context.Students.Remove(student);
			_context.SaveChanges();
		}

		public IEnumerable<Student> GetAll()
		{
			return _context.Students.ToList();
		}

		public Student GetById(int id)
		{
			return _context.Students.FirstOrDefault(x => x.Id == id);
		}

		public void Insert(Student student)
		{
			_context.Students.Add(student);
			_context.SaveChanges();
		}

		public void Update(Student student)
		{
			_context.Students.Update(student);
			_context.SaveChanges();
		}
	}
}
