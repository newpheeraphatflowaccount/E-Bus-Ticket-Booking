using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ETicketBooking.Entities;
using ETicketBooking.UI.ViewModels.DepartmentViewModels;
using ETicketBooking.UI.ViewModels.SubjectViewModels;

namespace ETicketBooking.UI.Mappers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Department, DepartmentViewModel>().ReverseMap();
			CreateMap<CreateDepartmentViewModel, Department>();
			CreateMap<Subject, SubjectViewModel>();
		}
	}
}
