using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.Entities;

namespace ETicketBooking.Repositories.Interfaces
{
	public interface IStudentRepo
	{
		IEnumerable<Student> GetAll();
		Student GetById(int id);
		void Insert(Student student);
		void Update(Student student);
		void Delete(int id);
	}
}
