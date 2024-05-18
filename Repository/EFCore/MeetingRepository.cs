using Entitiyes.Models;
using Entitiyes.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using Repository.EFCore.Extensions;
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
        public async Task<IEnumerable<Meeting>> GetAllMeetings(bool trackChanges) => await FindAll(trackChanges).OrderBy(x => x.Id).ToListAsync();
        public async Task<PagedList<Meeting>> GetAllMeetingsPage(MeetingParameters meetingParameters, bool trackChanges)
        {
          var meeting =  await FindAll(trackChanges)
        .OrderBy(x => x.Id)
        .MeetingSearch(meetingParameters.SearchTerm)
        .ShortMeeting(meetingParameters.OrderBy)
        .ToListAsync();
            return PagedList<Meeting>.ToPagedList(meeting, meetingParameters.PageNumber, meetingParameters.PageSize);
        }
        public async Task<Meeting> GetOneMeetingById(Guid id, bool trackChanges) =>await FindByConddition(x=>x.Id.Equals(id),trackChanges).SingleOrDefaultAsync();


      
       
    }
}
