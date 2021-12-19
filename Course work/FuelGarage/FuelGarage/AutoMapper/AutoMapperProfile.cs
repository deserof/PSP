using AutoMapper;
using FuelGarage.Domain.Entities;
using FuelGarage.Domain.ViewModels;

namespace FuelGarage.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Order, CustomerOrderViewModel>()
                .ForMember(x => x.FuelBrand,
                    map => map.MapFrom(s => s.Fuel == null ? "no data" : s.Fuel.Brand ?? "no data"))
                .ForMember(x => x.Status,
                    map => map.MapFrom(s => s.Status == null ? "no data" : s.Status.StatusName ?? "no data"))
                .ForMember(x => x.DriverFirstName,
                    map => map.MapFrom(s => s.Driver == null ? "no data" : s.Driver.FirstName ?? "no data"))
                .ForMember(x => x.DriverLastName,
                    map => map.MapFrom(s => s.Driver == null ? "no data" : s.Driver.LastName ?? "no data"))
                .ForMember(x => x.DriverMiddleName,
                    map => map.MapFrom(s => s.Driver == null ? "no data" : s.Driver.MiddleName ?? "no data"))
                .ForMember(x => x.DriverPhone,
                    map => map.MapFrom(s => s.Driver == null ? "no data" : s.Driver.Phone ?? "no data"));

            CreateMap<Order, DriverOrderViewModel>()
                .ForMember(x => x.FuelBrand,
                    map => map.MapFrom(s => s.Fuel == null ? "no data" : s.Fuel.Brand ?? "no data"))
                .ForMember(x => x.Status,
                    map => map.MapFrom(s => s.Status == null ? "no data" : s.Status.StatusName ?? "no data"))
                .ForMember(x => x.CustomerFirstName,
                    map => map.MapFrom(s => s.Driver == null ? "no data" : s.Driver.FirstName ?? "no data"))
                .ForMember(x => x.CustomerLastName,
                    map => map.MapFrom(s => s.Driver == null ? "no data" : s.Driver.LastName ?? "no data"))
                .ForMember(x => x.CustomerMiddleName,
                    map => map.MapFrom(s => s.Driver == null ? "no data" : s.Driver.MiddleName ?? "no data"))
                .ForMember(x => x.CustomerPhone,
                    map => map.MapFrom(s => s.Driver == null ? "no data" : s.Driver.Phone ?? "no data"));

            CreateMap<Order, NewOrderViewModel>()
                .ForMember(x => x.Address,
                    map => map.MapFrom(s => s.OrderAddress))
                .ForMember(x => x.FuelName,
                    map => map.MapFrom(s => s.Fuel == null ? "no data" : s.Fuel.Brand ?? "no data"))
                .ForMember(x => x.CustomerName,
                    map => map.MapFrom(s => $"{s.Customer.LastName} {s.Customer.FirstName[0]}. {s.Customer.MiddleName[0]}."));

            CreateMap<Fuel, FuelViewModel>().ReverseMap();

            CreateMap<Order, AdminOrderViewModel>()
                .ForMember(x => x.FuelBrand,
                    map => map.MapFrom(s => s.Fuel == null ? "no data" : s.Fuel.Brand ?? "no data"))
                .ForMember(x => x.Status,
                    map => map.MapFrom(s => s.Status == null ? "no data" : s.Status.StatusName ?? "no data"))
                .ForMember(x => x.Customer,
                    map => map.MapFrom(s => $"{s.Customer.LastName} {s.Customer.FirstName[0]}. {s.Customer.MiddleName[0]}."));

            CreateMap<User, DriverFullNameViewModel>()
                .ForMember(x => x.Name,
                    map => map.MapFrom(s => $"{s.LastName} {s.FirstName} {s.MiddleName}"));

            CreateMap<User, AdminCustomerViewModel>()
                .ForMember(x => x.Role,
                    map => map.MapFrom(s => s.Role.RoleName));

            CreateMap<AdminCustomerViewModel, User>();

            CreateMap<User, AdminDriverViewModel>()
                .ForMember(x => x.Role,
                map => map.MapFrom(s => s.Role.RoleName))
                .ForMember(x => x.Vehicle,
                    map => map.MapFrom(s => s.Vehicle == null ? "Без машины" : $"{s.Vehicle.Brand} {s.Vehicle.Model}"));

            CreateMap<Vehicle, VehicleViewModel>()
                .ForMember(x => x.Name,
                map => map.MapFrom(s => $"{s.Brand} {s.Model}"));

            CreateMap<VehicleViewModel, Vehicle>()
                .ForMember(x => x.Model,
                map => map.MapFrom(s => s.Model));

            CreateMap<User, CustomerFullName>()
                .ForMember(x => x.FullName,
                    map => map.MapFrom(s => $"{s.LastName} {s.FirstName} {s.MiddleName}"))
                .ForMember(x => x.Role,
                map => map.MapFrom(s => s.Role.RoleName));
        }
    }
}
