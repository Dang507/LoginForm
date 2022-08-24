using Api.Models;
using Api.Models.Dtos;
using AutoMapper;

namespace Api.Helpers
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, AuthenticateResponse>();
            CreateMap<RegisterRequest, Customer>();
        }
    }
}
