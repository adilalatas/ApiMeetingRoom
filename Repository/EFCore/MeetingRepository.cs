using Entitiyes.Dto;
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
        RepositoryContext _context;
        public MeetingRepository(RepositoryContext context) : base(context)
        {
            _context = context;
        }
        public void CreateOneMeeting(Meeting meeting) => Create(meeting);   
        public void DeleteOneMeeting(Meeting meeting) => Delete(meeting);
        public void UpdateOneMeeting(Meeting meeting) => Update(meeting);
        public async Task<IEnumerable<MeetingDto>> GetAllMeetings(bool trackChanges) {

            var meetingDto = (from meeting in _context.Meetings
                         join room in _context.Room on meeting.RoomId equals room.Id
                         join user in _context.Users on meeting.CreateUserId equals user.Id
                         where meeting.IsActive
                         select new MeetingDto 
                         {
                             UserFirstName = user.FirstName,
                             UserLastName = user.LastName,
                             RoomName = room.Name,
                             Title = meeting.Title,
                             EndDate = meeting.EndDate,
                             StartDate = meeting.StartDate,
                             Content = meeting.Content,
                             CreateDate = meeting.CreateDate,
                             CreateUserId = meeting.CreateUserId,
                             Id = meeting.Id,
                             RoomId = room.Id,
                             
                         }).ToList();
            return meetingDto;
            // await FindAll(trackChanges).Where(x => x.IsActive).OrderBy(x => x.Id).ToListAsync()

        }
        public async Task<PagedList<Meeting>> GetAllMeetingsPage(MeetingParameters meetingParameters, bool trackChanges)
        {
          var meeting =  await FindAll(trackChanges).Where(x => x.IsActive)
        .OrderBy(x => x.Id)
        .MeetingSearch(meetingParameters.SearchTerm)
        .ShortMeeting(meetingParameters.OrderBy)
        .ToListAsync();
            return PagedList<Meeting>.ToPagedList(meeting, meetingParameters.PageNumber, meetingParameters.PageSize);
        }
        public async Task<Meeting?> GetOneMeetingById(Guid id, bool trackChanges) =>await FindByConddition(x=>x.Id.Equals(id),trackChanges).Where(x => x.IsActive).SingleOrDefaultAsync();
        public async Task<IEnumerable<Meeting>> GetAllMeetingRoomId(Guid id, bool trackChanges) =>await FindByConddition(x=>x.RoomId.Equals(id),trackChanges).Where(x => x.IsActive).ToListAsync();
        //public async Task<IEnumerable<Meeting>> GetAllMeetingUserId(string id, bool trackChanges) => await FindByConddition(x => x.CreateUserId.Equals(id), trackChanges).Where(x => x.IsActive).ToListAsync();
        public async Task<IEnumerable<MeetingDto>> GetAllMeetingUserId(string id, bool trackChanges)
        {
            var meetingDto = (from meeting in _context.Meetings
                              join room in _context.Room on meeting.RoomId equals room.Id
                              join user in _context.Users on meeting.CreateUserId equals user.Id
                              where user.Id==id && meeting.IsActive
                              select new MeetingDto
                              {
                                  UserFirstName = user.FirstName,
                                  UserLastName = user.LastName,
                                  RoomName = room.Name,
                                  Title = meeting.Title,
                                  EndDate = meeting.EndDate,
                                  StartDate = meeting.StartDate,
                                  Content = meeting.Content,
                                  CreateDate = meeting.CreateDate,
                                  CreateUserId = meeting.CreateUserId,
                                  Id = meeting.Id,
                                  RoomId = room.Id,

                              }).ToList();
            return meetingDto;
        } 




    }
}
