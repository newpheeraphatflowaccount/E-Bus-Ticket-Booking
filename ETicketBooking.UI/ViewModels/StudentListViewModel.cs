using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketBooking.UI.ViewModels
{
	public class StudentListViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		[Display(Name="Profile Image")]
		public string? ProfileImageUrl { get; set; }
	}
}
