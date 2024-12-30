using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.Entities;
using ETicketBooking.Repositories.Interfaces;

namespace ETicketBooking.Repositories.Implementations
{
	public class SubjectRepo : ISubjectRepo
	{
		private readonly ApplicationDbContext _context;

		public SubjectRepo(ApplicationDbContext context)
		{
			_context = context;
		}

		public void Delete(int id)
		{
			var subject = GetById(id);
			_context.Subjects.Remove(subject);
			_context.SaveChanges();
		}

		public IEnumerable<Subject> GetAll()
		{
			return _context.Subjects.ToList();
		}

		public Subject GetById(int id)
		{
			return _context.Subjects.FirstOrDefault(x => x.Id == id);
		}

		public void Insert(Subject subject)
		{
			_context.Subjects.Add(subject);
			_context.SaveChanges();
		}

		public void Update(Subject subject)
		{
			_context.Subjects.Update(subject);
			_context.SaveChanges();
		}
	}
}
