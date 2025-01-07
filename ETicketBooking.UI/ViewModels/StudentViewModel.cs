using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketBooking.UI.ViewModels
{
	public class StudentViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? ProfileImage { get; set; }
		public IFormFile? ImagePath { get; set; }
		public List<CheckBoxTable> SubjectList { get; set; } = new List<CheckBoxTable>();
	}

	public class CheckBoxTable
	{
		public int Id { get; set; }
		public bool IsChecked { get; set; }
		public string Text { get; set; }
	}
}
