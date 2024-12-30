using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketBooking.Entities
{
	public class Subject
	{
		public int Id { get; set; }
		public string Name { get; set; }
		// Navigation Property
		public ICollection<StudentSubject> StudentSubjects { get; set; } =
			new List<StudentSubject>();
	}
}
