using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.Entities;
using ETicketBooking.Repositories.Interfaces;

namespace ETicketBooking.Repositories.Implementations
{
	public class DepartmentRepo : IDepartmentRepo
	{
		private readonly ApplicationDbContext _context;

		public DepartmentRepo(ApplicationDbContext context)
		{
			_context = context;
		}

		public void Delete(int id)
		{
			var department = GetById(id);
			_context.Departments.Remove(department);
			_context.SaveChanges();
		}

		public Department GetById(int id)
		{
			return _context.Departments.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Department> GetAll()
		{
			var departments = _context.Departments.ToList();
			return departments;
		}

		public void Insert(Department department)
		{
			_context.Departments.Add(department);
			_context.SaveChanges();
		}

		public void Update(Department department)
		{
			_context.Departments.Update(department);
			_context.SaveChanges();
		}
	}
}
