using Entitiyes.Dto;

namespace Services.Contracts
{
    public interface IMeetingService
    {
        Task<IEnumerable<MeetingDto>> GetAllMeetings(bool trackChanges);
        Task<MeetingDto> GetOneMeetingById(int id, bool trackChanges);
        Task<MeetingDto> CreateOneMeeting(MeetingDto book);
        Task UpdateOneMeeting(int id, MeetingDto meetingDto, bool trackChanges);
        Task DeleteOneMeeting(int id, bool trackChanges);
   
    }
}
