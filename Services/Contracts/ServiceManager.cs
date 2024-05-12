using AutoMapper;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMeetingService> _meetingService;
        private readonly Lazy<IRoomService> _roomService;
        public ServiceManager(IRepositoryManager repositoryManager,ILoggerService logger,IMapper mapper)
        {
            _meetingService = new Lazy<IMeetingService>(()=> new MeetingManager(repositoryManager,logger,mapper));
            _roomService = new Lazy<IRoomService>(()=> new RoomManager(repositoryManager,logger,mapper));
        }
        public IMeetingService MeetingService => _meetingService.Value;

        public IRoomService RoomService => _roomService.Value;

    }
}
