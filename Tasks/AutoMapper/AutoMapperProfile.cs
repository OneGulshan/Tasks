using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;

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
