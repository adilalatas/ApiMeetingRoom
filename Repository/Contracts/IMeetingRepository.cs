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
    public interface IMeetingRepository : IRepositoryBase<Meeting>
    {
        Task<IEnumerable<Meeting>> GetAllMeetings(bool trackChanges);
        Task<PagedList<Meeting>> GetAllMeetingsPage(MeetingParameters meetingParameters,bool trackChanges);
        Task<Meeting> GetOneMeetingById(int id,bool trackChanges);
        void CreateOneMeeting(Meeting meeting);
        void UpdateOneMeeting(Meeting meeting);
        void DeleteOneMeeting(Meeting meeting);
    }
}
