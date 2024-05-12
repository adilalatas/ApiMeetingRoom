using Entitiyes.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(RepositoryContext context) : base(context)
        {
            
        }
        public void CreateOneRoom(Room room) => Create(room);   
        public void DeleteOneRoom(Room room) => Delete(room);
        public void UpdateOneRoom(Room room) => Update(room);
        public async Task<IEnumerable<Room>> GetAllRooms(bool trackChanges) => await FindAll(trackChanges).ToListAsync();
        public async Task<Room> GetOneRoomById(int id, bool trackChanges) =>await FindByConddition(x=>x.Id.Equals(id),trackChanges).SingleOrDefaultAsync();


      
       
    }
}
