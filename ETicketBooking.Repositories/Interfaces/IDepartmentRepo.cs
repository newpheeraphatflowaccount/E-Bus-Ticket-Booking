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
		Task<IEnumerable<Department>> GetAll();
		Task<Department> GetById(int id);
		Task<int> Insert(Department department);
		Task Update(Department department);
		Task Delete(int id);
	}
}
