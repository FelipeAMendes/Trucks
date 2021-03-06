using AutoMapper;
using Mendes.Trucks.Application.ViewModels.Trucks;
using Mendes.Trucks.Application.ViewModels.Users;
using Mendes.Trucks.Domain.Entities;
using Mendes.Trucks.Domain.Extensions;

namespace Mendes.Trucks.Application.AutoMapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Truck, TruckViewModel>()
				.ReverseMap();
			CreateMap<Truck, TruckListViewModel>()
				.ForMember(dest => dest.TruckModel, opt => opt.MapFrom(src => src.TruckModel.GetDisplayName()))
				.ForMember(dest => dest.ManufactureYear, opt => opt.MapFrom(src => src.ManufactureYear))
				.ForMember(dest => dest.ModelYear, opt => opt.MapFrom(src => src.ModelYear));
			CreateMap<User, UserViewModel>()
				.ReverseMap();
			CreateMap<User, UserListViewModel>()
				.ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf.FormatCpf()));
		}
	}
}
