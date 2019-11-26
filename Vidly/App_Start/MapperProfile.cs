using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MapperProfile :Profile
    {

        public MapperProfile()
        {
            //Domain To Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movies, MovieDto>();
            Mapper.CreateMap<MemberShipType, MemberShipTypeDto>();
            //Dto To Domain 
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c=>c.CustomerId,opt=>opt.Ignore());
            Mapper.CreateMap<MovieDto, Movies>().ForMember(m=>m.Id,opt=>opt.Ignore());
        }

            
    }
}