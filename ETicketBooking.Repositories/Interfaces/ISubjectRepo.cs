using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.Entities;

namespace ETicketBooking.Repositories.Interfaces
{
	public interface ISubjectRepo
	{
		Task<IEnumerable<Subject>> GetAll();
		Task<Subject> GetById(int id);
		Task Insert(Subject subject);
		Task Update(Subject subject);
		Task Delete(int id);
	}
}
