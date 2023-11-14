using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig:Profile //Dto'larımız ve entitylerimizi bağlayacağımız sınıf
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
        }
    }
}
