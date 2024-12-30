using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.Web.Models;
using Microsoft.EntityFrameworkCore;


namespace ETicketBooking.Web.Data
{
	public class ApplicationDbContext : DbContext // ORM Object Relational Mapper
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) 
		{
			
		}

		public DbSet<Student> Students { get; set; }
	}
}
