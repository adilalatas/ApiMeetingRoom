using AutoMapper;
using Entitiyes.Dto;
using Entitiyes.Exceptions;
using Entitiyes.Models;
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

        public async Task DeleteOneMeeting(int id, bool trackChanges)
        {

           var entity = await GetOneMeetingAndCheck(id, trackChanges);
            _manager.Meeting.Delete(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<MeetingDto>> GetAllMeetings(bool trackChanges)
        {
           var books =await _manager.Meeting.GetAllMeetings(trackChanges);
            return _mapper.Map<IEnumerable<MeetingDto>>(books);
        }

        public async Task<MeetingDto> GetOneMeetingById(int id, bool trackChanges)
        {
            var entity = await GetOneMeetingAndCheck(id, trackChanges);
            return _mapper.Map<MeetingDto>(entity);

        }

        public async Task UpdateOneMeeting(int id, MeetingDto MeetingDto, bool trackChanges)
        {
            var entity = await GetOneMeetingAndCheck(id, trackChanges);
            entity = _mapper.Map<Meeting>(MeetingDto);     
            _manager.Meeting.UpdateOneMeeting(entity);
              await  _manager.SaveAsync();

        }
        private async Task<Meeting> GetOneMeetingAndCheck(int id, bool trackChanges){
            var entity = await _manager.Meeting.GetOneMeetingById(id, trackChanges);
            if (entity is null)
                throw new BookNotFoundException(id);

            return entity;

        }
    }
}
