using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.Entities;
using ETicketBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ETicketBooking.Repositories.Implementations
{
	public class UserRepo : IUserRepo
	{
		private ApplicationDbContext _context;

		public UserRepo(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<UserInfo> Login(string userName, string password)
		{
			return await _context.UserInfos.FirstOrDefaultAsync(x => x.UserName.ToLower() == userName && x.Password == password);
		}

		public async Task Register(UserInfo userInfo)
		{
			await _context.UserInfos.AddAsync(userInfo);
			await _context.SaveChangesAsync();
		}
	}
}
