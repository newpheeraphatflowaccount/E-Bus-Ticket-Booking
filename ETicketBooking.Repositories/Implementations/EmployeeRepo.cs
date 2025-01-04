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
	public class EmployeeRepo : IEmployeeRepo
	{
		private readonly ApplicationDbContext _context;

		public EmployeeRepo(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Delete(int id)
		{
			var employee = await GetById(id);
			_context.Employees.Remove(employee);
			await _context.SaveChangesAsync();
		}

		public async Task<Employee> GetById(int id)
		{
			return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IEnumerable<Employee>> GetAll()
		{
			return await _context.Employees.Include(x => x.Department).ToListAsync();
		}

		public async Task Insert(Employee employee)
		{
			await _context.Employees.AddAsync(employee);
			await _context.SaveChangesAsync();
		}

		public async Task Update(Employee employee)
		{
			_context.Employees.Update(employee);
			await _context.SaveChangesAsync();
		}
	}
}
