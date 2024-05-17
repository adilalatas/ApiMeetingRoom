using Entitiyes.Models;
using Entitiyes.RequestFeatures;
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
        public async Task<IEnumerable<Room>> GetAllRoom(bool trackChanges) => await FindAll(trackChanges).OrderBy(x=>x.Id).ToListAsync();
        public async Task<PagedList<Room>> GetAllRoomPage(RoomParameters roomParameters, bool trackChanges)
        {

            var room = await FindAll(trackChanges).OrderBy(x => x.Id).ToListAsync();
            return PagedList<Room>.ToPagedList(room, roomParameters.PageNumber, roomParameters.PageSize);

         }
        public async Task<Room> GetOneRoomById(int id, bool trackChanges) => await FindByConddition(x => x.Id.Equals(id), trackChanges).SingleOrDefaultAsync();




    }
}
