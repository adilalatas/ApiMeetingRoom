using Entitiyes.Dto;
using Entitiyes.RequestFeatures;

namespace Services.Contracts
{
    public interface IMeetingService
    {
        Task<IEnumerable<MeetingDto>> GetAllMeetings(bool trackChanges);
        Task<(IEnumerable<MeetingDto> meetings,MetaData metaData)> GetAllMeetingsPage(MeetingParameters meetingParameters,bool trackChanges);
        Task<MeetingDto> GetOneMeetingById(int id, bool trackChanges);
        Task<MeetingDto> CreateOneMeeting(MeetingDto book);
        Task UpdateOneMeeting(int id, MeetingDto meetingDto, bool trackChanges);
        Task DeleteOneMeeting(int id, bool trackChanges);
   
    }
}
