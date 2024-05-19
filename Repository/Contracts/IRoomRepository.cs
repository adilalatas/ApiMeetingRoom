using Entitiyes.Dto;
using Entitiyes.Models;
using Entitiyes.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IRoomRepository : IRepositoryBase<Room>
    {
        Task<IEnumerable<Room>> GetAllRoom(bool trackChanges);
        Task<PagedList<Room>> GetAllRoomPage(RoomParameters roomParameters,bool trackChanges);
        Task<Room?> GetOneRoomById(Guid id,bool trackChanges);
        void CreateOneRoom(Room room);
        void UpdateOneRoom(Room room);
        void DeleteOneRoom(Room room);
    }
}
