using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicketBooking.Entities;

namespace ETicketBooking.Repositories.Interfaces
{
	public interface IDepartmentRepo
	{
		IEnumerable<Department> GetAll();
		Department GetById(int id);
		void Insert(Department department);
		void Update(Department department);
		void Delete(int id);
	}
}
