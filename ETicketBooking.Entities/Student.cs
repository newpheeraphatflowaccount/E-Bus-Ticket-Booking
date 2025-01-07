using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketBooking.Entities
{
	// Student (1)-----(*) StudentSubject (*)-----(1) Subject
	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
		// Navigation Property
		public Address Address { get; set; }
		public string? ProfileImageUrl { get; set; }
		// Navigation Property
		public ICollection<StudentSubject> StudentSubjects { get; set; } = 
			new List<StudentSubject>();
	}
}
