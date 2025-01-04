using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketBooking.UI.ViewModels
{
	public class CreateStudentViewModel
	{
		public string Name { get; set; }
		public List<CheckBoxTable> SubjectList { get; set; } = new List<CheckBoxTable>();
	}
}
