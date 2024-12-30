using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketBooking.Entities
{
	public class StudentSubject
	{
		public int StudentId { get; set; } // Foreign Key
		public Student Student { get; set; }
		public int SubjectId { get; set; } // Foreign Key
		public Subject Subject { get; set; } 
	}
}

// Student			StudentSubject				Subject
// Id | Name		StudentId | SubjectId		Id	|	Name
// 1	Jacob		1			1				1		English	
// 2	Smith		1			2				2		Science
//					2			1
//					2			2		