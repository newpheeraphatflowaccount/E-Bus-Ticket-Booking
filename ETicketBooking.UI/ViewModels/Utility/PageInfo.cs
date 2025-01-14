using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketBooking.UI.ViewModels.Utility
{
	public class PageInfo
	{
		public int PageNumber { get; set; } // 1
		public int PageSize { get; set; } // 10
		public int TotalItems { get; set; } // 105
		public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize); // 105 / 10 = 11
		public bool HasPreviousPage => PageNumber > 1;
		public bool HasNextPage => PageNumber < TotalPages;
	}
}
