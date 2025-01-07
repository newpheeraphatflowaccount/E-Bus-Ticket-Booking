using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.UI.Validations;

namespace ETicketBooking.UI.ViewModels.DepartmentViewModels
{
	public class CreateDepartmentViewModel
	{
		[Required(ErrorMessage = "Name Required")]
		[FirstLetterUpperCase]
		public string Name { get; set; }
	}
}
