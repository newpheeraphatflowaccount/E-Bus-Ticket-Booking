using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketBooking.Entities
{
	// Department (1)-------------(*) Employees
	public class Department
	{
		public int Id { get; set; }
		public string Name { get; set; }
		// Navigation Property
		public ICollection<Employee> Employees { get; set; }
	}
}
