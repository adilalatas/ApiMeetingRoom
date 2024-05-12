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
    public class MeetingRepository : RepositoryBase<Meeting>, IMeetingRepository
    {
        public MeetingRepository(RepositoryContext context) : base(context)
        {
            
        }
        public void CreateOneMeeting(Meeting meeting) => Create(meeting);   
        public void DeleteOneMeeting(Meeting meeting) => Delete(meeting);
        public void UpdateOneMeeting(Meeting meeting) => Update(meeting);
        public async Task<IEnumerable<Meeting>> GetAllMeetings(bool trackChanges) => await FindAll(trackChanges).ToListAsync();
        public async Task<Meeting> GetOneMeetingById(int id, bool trackChanges) =>await FindByConddition(x=>x.Id.Equals(id),trackChanges).SingleOrDefaultAsync();


      
       
    }
}
