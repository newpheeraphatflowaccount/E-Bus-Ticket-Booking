using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketBooking.Entities
{
	// Department (1)-------------(*) Employees
	public class Department
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		// Navigation Property
		[NotMapped]
		public ICollection<Employee> Employees { get; set; } = new List<Employee>();
	}
}
