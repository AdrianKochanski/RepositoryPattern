using AutoMapper;
using DatabaseRepPattern.Models;
using DatabaseRepPattern.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseRepPattern.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Customer, CustomerSimpleDto>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.dateOfBirth.Age()));
            CreateMap<Customer, CustomerDetailDto>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.dateOfBirth.Age()));
            CreateMap<Customer, CustomerStandardDto>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.dateOfBirth.Age()));
            CreateMap<Order, OrderDto>();
            CreateMap<Item, ItemDto>();
        }
    }
}
