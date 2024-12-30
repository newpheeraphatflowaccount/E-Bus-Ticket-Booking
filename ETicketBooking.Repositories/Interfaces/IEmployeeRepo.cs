using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.Entities;

namespace ETicketBooking.Repositories.Interfaces
{
	public interface IEmployeeRepo
	{
		IEnumerable<Employee> GetAll();
		Employee GetById(int id);
		void Insert(Employee employee);
		void Update(Employee employee);
		void Delete(int id);
	}
}
