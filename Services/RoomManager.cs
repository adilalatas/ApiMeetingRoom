using AutoMapper;
using Entitiyes.Dto;
using Entitiyes.Exceptions;
using Entitiyes.Models;
using Entitiyes.RequestFeatures;
using Repository.Contracts;
using Services.Contracts;

namespace Services
{
    public class RoomManager : IRoomService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public RoomManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Room> CreateOneRoom(RoomDto roomDto)
        {           
           var entity = _mapper.Map<Room>(roomDto);        
           _manager.Room.CreateOneRoom(entity);
           await _manager.SaveAsync();
           return _mapper.Map<Room>(entity);          
        }

        public async Task DeleteOneRoom(Guid id, bool trackChanges)
        {

           var entity = await GetOneRoomAndCheck(id, trackChanges);
            var meeeting =await _manager.Meeting.GetAllMeetingRoomId(id,trackChanges);
            if (meeeting.Count() != 0) {
                throw new Exception("İçerisinde Toplantı Bulunan Toplantı Odaları Silinemez.");
            }
            _manager.Room.DeleteOneRoom(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<RoomDto>> GetAllRoom(bool trackChanges)
        {
            var room = await _manager.Room.GetAllRoom(trackChanges);
            return _mapper.Map<IEnumerable<RoomDto>>(room);
        }  
        public async Task<(IEnumerable<RoomDto> rooms, MetaData metaData)> GetAllRoomPage(RoomParameters roomParameters,bool trackChanges)
        {
           var roomMetaData = await _manager.Room.GetAllRoomPage(roomParameters,trackChanges);
            var roomDto=  _mapper.Map<IEnumerable<RoomDto>>(roomMetaData);
            return (roomDto, roomMetaData.MetaData);

        }

        public async Task<Room> GetOneRoomById(Guid id, bool trackChanges)
        {
            var entity = await GetOneRoomAndCheck(id, trackChanges);
            return _mapper.Map<Room>(entity);

        }

        public async Task UpdateOneRoom(Guid id, RoomDto MeetingDto, bool trackChanges)
        {
            var entity = await GetOneRoomAndCheck(id, trackChanges);
            entity = _mapper.Map<Room>(MeetingDto);
          _manager.Room.UpdateOneRoom(entity);
              await  _manager.SaveAsync();

        }
        private async Task<Room> GetOneRoomAndCheck(Guid id, bool trackChanges){
            var entity = await _manager.Room.GetOneRoomById(id, trackChanges);
            if (entity is null)
                throw new Exception("Toplantı Odası Bulunamadı. ");

            return entity;

        }
    }
}
