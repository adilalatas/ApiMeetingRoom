using Entitiyes.Dto;
using Entitiyes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IRoomRepository : IRepositoryBase<Room>
    {
        Task<IEnumerable<Room>> GetAllRooms(bool trackChanges);
        Task<Room> GetOneRoomById(int id,bool trackChanges);
        void CreateOneRoom(Room room);
        void UpdateOneRoom(Room room);
        void DeleteOneRoom(Room room);
    }
}
