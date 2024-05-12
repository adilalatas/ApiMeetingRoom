using AutoMapper;
using Entitiyes.Dto;
using Entitiyes.DTO;
using Entitiyes.Models;


namespace WebApiBook.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MeetingDto, Meeting>();
            CreateMap<Meeting, MeetingDto>();
            CreateMap<RoomDto, Room>();
            CreateMap<Room, RoomDto>();
            CreateMap<UserForRegistrationDto, User>();
            
        }
    }
}
