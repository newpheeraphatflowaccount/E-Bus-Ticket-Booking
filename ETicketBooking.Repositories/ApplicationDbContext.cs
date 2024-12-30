using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.Entities;
using Microsoft.EntityFrameworkCore;


namespace ETicketBooking.Repositories
{
	public class ApplicationDbContext : DbContext // ORM Object Relational Mapper
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) 
		{
			
		}

		public DbSet<Department> Departments { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<StudentSubject>().HasKey(x => new { x.SubjectId, x.StudentId }); 
			base.OnModelCreating(modelBuilder);
		}
	}
}
