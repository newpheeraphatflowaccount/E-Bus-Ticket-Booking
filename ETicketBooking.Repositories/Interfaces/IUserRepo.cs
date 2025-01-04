using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.Entities;

namespace ETicketBooking.Repositories.Interfaces
{
	public interface IUserRepo
	{
		Task Register(UserInfo userInfo);
		Task<UserInfo> Login(string userName, string password);
	}
}
