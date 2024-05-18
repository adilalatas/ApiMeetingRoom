using Entitiyes.Dto;
using Entitiyes.Models;
using Entitiyes.RequestFeatures;

namespace Services.Contracts
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllRoom(bool trackChanges);
        Task<(IEnumerable<RoomDto> rooms,MetaData metaData)> GetAllRoomPage(RoomParameters roomParameters,bool trackChanges);
        Task<Room> GetOneRoomById(Guid id, bool trackChanges);
        Task<Room> CreateOneRoom(RoomDto roomDto);
        Task UpdateOneRoom(Guid id, RoomDto roomDto, bool trackChanges);
        Task DeleteOneRoom(Guid id, bool trackChanges);
   
    }
}
