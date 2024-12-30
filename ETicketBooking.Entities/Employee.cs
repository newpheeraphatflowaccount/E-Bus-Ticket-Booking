using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketBooking.Entities
{
	// Employee (1)------------(1) Department
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int DepartmentId { get; set; } // Foreign Key of the Table
		// Navigation Property
		public Department Department { get; set; }
	}
}

// Department						Employee
// Id | Name						Id | Name | DepartmentId
// 1  | IT							1  | John | 1
// 2  | HR							2  | Doe  | 2
// 3  | Finance						3  | Jane | 1