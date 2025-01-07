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
	public class DepartmentRepo : IDepartmentRepo
	{
		private readonly ApplicationDbContext _context;

		public DepartmentRepo(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Delete(int id)
		{
			var department = await GetById(id);
			_context.Departments.Remove(department);
			await _context.SaveChangesAsync();
		}

		public async Task<Department> GetById(int id)
		{
			return await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IEnumerable<Department>> GetAll()
		{
			return await _context.Departments.ToListAsync();
		}

		public async Task<int> Insert(Department department)
		{
			int record = 0;
			if (department != null)
			{
				await _context.Departments.AddAsync(department);
				record = await _context.SaveChangesAsync();
			}
			return record;
		}

		public async Task Update(Department department)
		{
			_context.Departments.Update(department);
			await _context.SaveChangesAsync();
		}
	}
}
