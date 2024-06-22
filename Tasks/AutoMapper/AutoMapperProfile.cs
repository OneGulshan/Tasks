using AutoMapper;
using Tasks.Models;
using Tasks.ViewModal;

namespace Tasks.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Country, CountryVm>();
            CreateMap<State, StateVm>();
            CreateMap<City, CityVm>();
            CreateMap<Customer, CustomerVM>();
        }
    }
}
