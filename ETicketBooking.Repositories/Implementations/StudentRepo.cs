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
	public class StudentRepo : IStudentRepo
	{
		private readonly ApplicationDbContext _context;

		public StudentRepo(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Delete(int id)
		{
			var student = await GetById(id);
			_context.Students.Remove(student);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Student>> GetAll()
		{
			return await _context.Students.ToListAsync();
		}

		public async Task<Student> GetById(int id)
		{
			return await _context.Students.Include(y => y.StudentSubjects).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task Insert(Student student)
		{
			await _context.Students.AddAsync(student);
			await _context.SaveChangesAsync();
		}

		public async Task Update(Student student)
		{
			_context.Students.Update(student);
			await _context.SaveChangesAsync();
		}
	}
}
