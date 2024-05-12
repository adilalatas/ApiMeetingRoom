using Entitiyes.Dto;
using Entitiyes.Models;

namespace Services.Contracts
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllRooms(bool trackChanges);
        Task<Room> GetOneRoomById(int id, bool trackChanges);
        Task<Room> CreateOneRoom(RoomDto roomDto);
        Task UpdateOneRoom(int id, RoomDto roomDto, bool trackChanges);
        Task DeleteOneRoom(int id, bool trackChanges);
   
    }
}
