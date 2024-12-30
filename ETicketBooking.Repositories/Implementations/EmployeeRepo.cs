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

		public void Delete(int id)
		{
			var employee = GetById(id);
			_context.Employees.Remove(employee);
			_context.SaveChanges();
		}

		public Employee GetById(int id)
		{
			return _context.Employees.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Employee> GetAll()
		{
			var employees = _context.Employees.Include(x => x.Department).ToList();
			return employees;
		}

		public void Insert(Employee employee)
		{
			_context.Employees.Add(employee);
			_context.SaveChanges();
		}

		public void Update(Employee employee)
		{
			_context.Employees.Update(employee);
			_context.SaveChanges();
		}
	}
}
