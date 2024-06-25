using AutoMapper;
using Common.Dto;
using Repository.Entities;
using System;

using AutoMapper;
namespace Service
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {


            CreateMap<Animal, AnimalDto>()
                .ForMember(
                 dest => dest.Image,
         opt => opt.MapFrom(src =>
             src.Image != null
                 ? Convert.ToBase64String(System.IO.File.ReadAllBytes(src.Image))
                 : null)
         );
            CreateMap<AnimalDto, Animal>();


            CreateMap<User, UserDto>()
                .ForMember(
                 dest => dest.Image,
         opt => opt.MapFrom(src =>
             src.Image != null
                 ? Convert.ToBase64String(System.IO.File.ReadAllBytes(src.Image))
                 : null)
         );
            CreateMap<UserDto, User>();
            CreateMap<Zoo, ZooDto>().ReverseMap();
            CreateMap<Cage, CageDto>().ReverseMap();
            CreateMap<Kiosk, KioskDto>().ReverseMap();
            CreateMap<Ticket, TicketDto>().ReverseMap();
            CreateMap<Riddle, RiddleDto>().ReverseMap();
          

        }
    }
}
