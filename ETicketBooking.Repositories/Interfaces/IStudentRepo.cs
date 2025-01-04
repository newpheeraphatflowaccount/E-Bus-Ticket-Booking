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
		Task<IEnumerable<Student>> GetAll();
		Task<Student> GetById(int id);
		Task Insert(Student student);
		Task Update(Student student);
		Task Delete(int id);
	}
}
