using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.Entities;
using ETicketBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ETicketBooking.Repositories.Implementations
{
	public class SubjectRepo : ISubjectRepo
	{
		private readonly ApplicationDbContext _context;

		public SubjectRepo(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Delete(int id)
		{
			var subject = await GetById(id);
			_context.Subjects.Remove(subject);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Subject>> GetAll()
		{
			return await _context.Subjects.ToListAsync();
		}

		public async Task<Subject> GetById(int id)
		{
			return await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task Insert(Subject subject)
		{
			await _context.Subjects.AddAsync(subject);
			await _context.SaveChangesAsync();
		}

		public async Task Update(Subject subject)
		{
			_context.Subjects.Update(subject);
			await _context.SaveChangesAsync();
		}
	}
}
