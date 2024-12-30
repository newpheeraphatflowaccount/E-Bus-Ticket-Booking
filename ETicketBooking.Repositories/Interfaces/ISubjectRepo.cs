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
		IEnumerable<Subject> GetAll();
		Subject GetById(int id);
		void Insert(Subject subject);
		void Update(Subject subject);
		void Delete(int id);
	}
}
