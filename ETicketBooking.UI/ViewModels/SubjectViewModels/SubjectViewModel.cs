using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.UI.ViewModels.Utility;

namespace ETicketBooking.UI.ViewModels.SubjectViewModels
{
	public class SubjectViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class PagedSubjectViewModel
	{
		public List<SubjectViewModel> SubjectViewModelList { get; set; }
		public PageInfo PageInfo { get; set; }
	}
}
