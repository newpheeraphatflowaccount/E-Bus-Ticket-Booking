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
		Task<IEnumerable<Employee>> GetAll();
		Task<Employee> GetById(int id);
		Task Insert(Employee employee);
		Task Update(Employee employee);
		Task Delete(int id);
	}
}
