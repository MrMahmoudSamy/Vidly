using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MapperProfile :Profile
    {

        public MapperProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Movies, MovieDto>();
            Mapper.CreateMap<MovieDto, Movies>();
        }

            
    }
}