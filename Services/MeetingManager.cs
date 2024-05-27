using AutoMapper;
using Entitiyes.Dto;
using Entitiyes.Exceptions;
using Entitiyes.Models;
using Entitiyes.RequestFeatures;
using Repository.Contracts;
using Services.Contracts;

namespace Services
{
    public class MeetingManager : IMeetingService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public MeetingManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<MeetingDto> CreateOneMeeting(MeetingDto MeetingDto)
        {
    
            var entity = _mapper.Map<Meeting>(MeetingDto);
            _manager.Meeting.CreateOneMeeting(entity);
           await _manager.SaveAsync();
            return _mapper.Map<MeetingDto>(entity);
        }

        public async Task DeleteOneMeeting(Guid id, bool trackChanges)
        {

           var entity = await GetOneMeetingAndCheck(id, trackChanges);
            entity.IsActive = false;
            _manager.Meeting.Update(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<MeetingDto>> GetAllMeetings( bool trackChanges)
        {
           var meeting =await _manager.Meeting.GetAllMeetings(trackChanges);
            return meeting;
        }   
        public async Task<(IEnumerable<MeetingDto> meetings, MetaData metaData)> GetAllMeetingsPage(MeetingParameters meetingParameters,bool trackChanges)
        {
           var meetingMetaData = await _manager.Meeting.GetAllMeetingsPage(meetingParameters, trackChanges);
            var meetingDto = _mapper.Map<IEnumerable<MeetingDto>>(meetingMetaData);
            return (meetingDto, meetingMetaData.MetaData);
        }

        public async Task<MeetingDto> GetOneMeetingById(Guid id, bool trackChanges)
        {
            var entity = await GetOneMeetingAndCheck(id, trackChanges);
            return _mapper.Map<MeetingDto>(entity);

        }    
        public async Task<IEnumerable<MeetingDto>> GetAllMeetingRoomId(Guid id, bool trackChanges)
        {
            var entity = await _manager.Meeting.GetAllMeetingRoomId(id, trackChanges);
            return _mapper.Map<List<MeetingDto>>(entity);

        }

        public async Task<IEnumerable<MeetingDto>> GetAllMeetingUserId(string id, bool trackChanges)
        {
            var entity = await _manager.Meeting.GetAllMeetingUserId(id, trackChanges);
            return _mapper.Map<List<MeetingDto>>(entity);

        }

        public async Task UpdateOneMeeting(Guid id, MeetingDto MeetingDto, bool trackChanges)
        {
            var entity = await GetOneMeetingAndCheck(id, trackChanges);
            entity = _mapper.Map<Meeting>(MeetingDto);
            entity.Id = id;
            _manager.Meeting.UpdateOneMeeting(entity);
              await  _manager.SaveAsync();

        }
        private async Task<Meeting> GetOneMeetingAndCheck(Guid id, bool trackChanges){
            var entity = await _manager.Meeting.GetOneMeetingById(id, trackChanges);
            if (entity is null)
                throw new MeetingFoundException();

            return entity;

        }
    }
}
