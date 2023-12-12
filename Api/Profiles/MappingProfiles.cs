using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Api.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Addresstype, AddressTypeDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Contacttype, ContactTypeDto>().ReverseMap();
            CreateMap<Contract, ContractDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Personaddress, PersonAddressDto>().ReverseMap();
            CreateMap<Personcategory, PersonCategoryDto>().ReverseMap();
            CreateMap<Personcontact, PersonContactDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Persontype, PersonTypeDto>().ReverseMap();
            CreateMap<Programming, ProgramingDto>().ReverseMap();
            CreateMap<Shift, ShiftDto>().ReverseMap();
            CreateMap<State, StateDto>().ReverseMap();
        }
    }
}