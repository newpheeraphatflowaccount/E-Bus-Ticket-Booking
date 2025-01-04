using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketBooking.Entities
{
	public class Address
	{
		public int Id { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public int StudentId { get; set; } // Unique
		public Student Student { get; set; }
	}
}
