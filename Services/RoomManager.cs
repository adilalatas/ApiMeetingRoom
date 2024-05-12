using AutoMapper;
using Entitiyes.Dto;
using Entitiyes.Exceptions;
using Entitiyes.Models;
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

        public async Task DeleteOneRoom(int id, bool trackChanges)
        {

           var entity = await GetOneRoomAndCheck(id, trackChanges);
            _manager.Room.DeleteOneRoom(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<RoomDto>> GetAllRooms(bool trackChanges)
        {
            var room = await _manager.Room.GetAllRooms(trackChanges);
            return _mapper.Map<IEnumerable<RoomDto>>(room);
        }

        public async Task<Room> GetOneRoomById(int id, bool trackChanges)
        {
            var entity = await GetOneRoomAndCheck(id, trackChanges);
            return _mapper.Map<Room>(entity);

        }

        public async Task UpdateOneRoom(int id, RoomDto MeetingDto, bool trackChanges)
        {
            var entity = await GetOneRoomAndCheck(id, trackChanges);
            entity = _mapper.Map<Room>(MeetingDto);
          _manager.Room.UpdateOneRoom(entity);
              await  _manager.SaveAsync();

        }
        private async Task<Room> GetOneRoomAndCheck(int id, bool trackChanges){
            var entity = await _manager.Room.GetOneRoomById(id, trackChanges);
            if (entity is null)
                throw new MeetingFoundException(id);

            return entity;

        }
    }
}
