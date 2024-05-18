using Entitiyes.Dto;
using Entitiyes.RequestFeatures;

namespace Services.Contracts
{
    public interface IMeetingService
    {
        Task<IEnumerable<MeetingDto>> GetAllMeetings(bool trackChanges);
        Task<(IEnumerable<MeetingDto> meetings,MetaData metaData)> GetAllMeetingsPage(MeetingParameters meetingParameters,bool trackChanges);
        Task<MeetingDto> GetOneMeetingById(Guid id, bool trackChanges);
        Task<MeetingDto> CreateOneMeeting(MeetingDto meeting);
        Task UpdateOneMeeting(Guid id, MeetingDto meetingDto, bool trackChanges);
        Task DeleteOneMeeting(Guid id, bool trackChanges);
   
    }
}
